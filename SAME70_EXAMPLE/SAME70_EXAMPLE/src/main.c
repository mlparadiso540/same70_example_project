/*
 * SAME70_EXAMPLE
 *
 * Simple program for SAME70 XPLAINED board
 * I/O's are monitored and controlled via the SAME70_CLIENT included in the repository
 * LWIP is used for UDP communication between the XPLAINED and the client
 * 
 * Author: Matthew Longobardi Paradiso
 * Created: 1/4/2020
 *
 */ 

#include "sysclk.h"
#include "ioport.h"
#include "stdio_serial.h"
#include "ethernet.h"
#include "same70_gpio.h"
#include "system_timer.h"
#include "udp_comms.h"

#define TASK_INTERVAL 1000

/*
* Configure UART console for debugging
*/
static void configure_console(void)
{
	const usart_serial_options_t uart_serial_options = {
		.baudrate = CONF_UART_BAUDRATE,
		#if (defined CONF_UART_CHAR_LENGTH)
		.charlength = CONF_UART_CHAR_LENGTH,
		#endif
		.paritytype = CONF_UART_PARITY,
		#if (defined CONF_UART_STOP_BITS)
		.stopbits = CONF_UART_STOP_BITS,
		#endif
	};

	/* Configure UART console. */
	sysclk_enable_peripheral_clock(CONSOLE_UART_ID);
	stdio_serial_init(CONF_UART, &uart_serial_options);
	#if defined(__GNUC__)
	setbuf(stdout, NULL);
	#endif
}

/*
* main()
* Initialize components and run tasks
*/
int main(void)
{
	/* Initialize the SAM system. */
	sysclk_init();
	board_init();
	InitializeSystemTimer();
	InitializeIoPorts();
	
	/* Configure debug UART */
	configure_console();
	printf("Starting SAME70 example project\r\n");

	/* Bring up the ethernet interface & initialize timer0, channel0. */
	init_ethernet();
	
	/* Initialize udp socket for communication with client */
	while (init_udp_comms()) {
		//keep trying to initialize udp socket 
	}

	uint32_t task_timer = GetSystemTimeMilliseconds();

	printf("Entering main loop\r\n");
	
	/* Program main loop. */
	while (1) 
	{		
		/* Check for input packet and process it. */
		ethernet_task();
		
		//run the tasks every one second
		if (HasXMillisecondsElapsed(TASK_INTERVAL, task_timer)) 
		{
			//toggle led to indicate program is running
			ToggleLED();
			
			//report status of outputs/inputs to client
			udp_task();			
			
			//restart timer
			task_timer = GetSystemTimeMilliseconds();
		}
	}
}
