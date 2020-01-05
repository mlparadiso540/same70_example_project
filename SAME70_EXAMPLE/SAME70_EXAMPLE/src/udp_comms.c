/*
* udp_comms.c
*
* Created: 1/4/2020 7:53:38 PM
*  Author: Matt
*/

#include "udp_comms.h"
#include "udp.h"
#include "message_defines.h"
#include "same70_gpio.h"
#include "string.h"

#define LOCAL_UDP_PORT 7777
#define REMOTE_UDP_PORT 7778
#define UDP_BUFFER_SIZE 256

struct udp_pcb *udp_socket;
struct StatusMessage *status_message;
struct ControlMessage *control_message;
struct ip_addr dstaddr;
struct ip_addr srcaddr;

/* Incoming udp message handler */
static void udp_recv_message(void *arg, struct udp_pcb *upcb, struct pbuf *p, const ip_addr_t *addr, u16_t port)
{
	uint8_t* data;
	LWIP_UNUSED_ARG(arg);
	if (p != NULL) {
		data = p->payload;
		//check for header bytes
		if (data[0] != HEADER_BYTE_1) {
			pbuf_free(p);
			return;
		}
		if (data[1] != HEADER_BYTE_2) {
			pbuf_free(p);
			return;
		}
		if (data[2] != HEADER_BYTE_3) {
			pbuf_free(p);
			return;
		}
		if (data[3] != HEADER_BYTE_4) {
			pbuf_free(p);
			return;
		}
		
		//Good header, get message ID and size
		uint8_t msg_id = (uint8_t)data[4];
		uint8_t msg_size = (uint8_t)data[5];
		
		if (msg_id == CONTROL_MESSAGE_ID) {
			memcpy(control_message, data, CONTROL_MESSAGE_SIZE);
			printf("Received control message, output: %#X \r\n", control_message->output_status);
			ParseOutputControl(control_message->output_status);
		}		

		/* free the pbuf */
		pbuf_free(p);
	}
}

/* Initialize udp socket*/
int init_udp_comms(void)
{
	IP4_ADDR(&dstaddr,192,168,0,99); // destination
	IP4_ADDR(&srcaddr,192,168,0,100); // source
	
	control_message = (struct ControlMessage *) malloc(sizeof(struct ControlMessage));	
	status_message = (struct StatusMessage *) malloc(sizeof(struct StatusMessage));
	
	status_message->header_byte1 = HEADER_BYTE_1;
	status_message->header_byte2 = HEADER_BYTE_2;
	status_message->header_byte3 = HEADER_BYTE_3;
	status_message->header_byte4 = HEADER_BYTE_4;
	status_message->msg_id = STATUS_MESSAGE_ID;
	status_message->msg_size = STATUS_MESSAGE_SIZE;
	status_message->output_status = 0;
	status_message->input_status = 0;
	status_message->checksum = 0;
	
	udp_socket = udp_new();
	if (udp_socket == NULL) {
		return ERR_IF; //error opening udp socket
	}
	
	err_t err;
	//Listen for udp packets from any source on UDP_PORT
	err = udp_bind(udp_socket, &srcaddr, LOCAL_UDP_PORT);
	if (err == ERR_OK) {
		//specify handler for incoming udp data
		udp_recv(udp_socket, udp_recv_message, NULL);
	}
	
	return err;
}

/* udp task, send status message when called */
void udp_task(void) {
	status_message->output_status = GetOutputStatus();
	status_message->input_status = GetInputStatus();

	struct pbuf *udp_buffer = pbuf_alloc(PBUF_TRANSPORT, UDP_BUFFER_SIZE, PBUF_RAM);
	pbuf_take(udp_buffer, status_message, STATUS_MESSAGE_SIZE);
	udp_sendto(udp_socket, udp_buffer, &dstaddr, REMOTE_UDP_PORT);	
	pbuf_free(udp_buffer);	
}

/* Set outputs according to control message received */
void ParseOutputControl(uint8_t outputs) {
	SetOutputD0(outputs & OUTPUT_D0_MASK);	
	SetOutputD1((outputs & OUTPUT_D1_MASK) >> OUTPUT_D1_SHIFT);
	SetOutputD2((outputs & OUTPUT_D2_MASK) >> OUTPUT_D2_SHIFT);
	SetOutputD3((outputs & OUTPUT_D3_MASK) >> OUTPUT_D3_SHIFT);
	SetOutputD4((outputs & OUTPUT_D4_MASK) >> OUTPUT_D4_SHIFT);
	SetOutputD5((outputs & OUTPUT_D5_MASK) >> OUTPUT_D5_SHIFT);
	SetOutputD6((outputs & OUTPUT_D6_MASK) >> OUTPUT_D6_SHIFT);
	SetOutputD7((outputs & OUTPUT_D7_MASK) >> OUTPUT_D7_SHIFT);
}

uint8_t GetOutputStatus(void) {
	uint8_t status = 0;
	
	if (GetOutputD0()) {
		status |= OUTPUT_D0_MASK;
	}
	
	if (GetOutputD1()) {
		status |= OUTPUT_D1_MASK;
	}
	
	if (GetOutputD2()) {
		status |= OUTPUT_D2_MASK;
	}
	
	if (GetOutputD3()) {
		status |= OUTPUT_D3_MASK;
	}
	
	if (GetOutputD4()) {
		status |= OUTPUT_D4_MASK;
	}
	
	if (GetOutputD5()) {
		status |= OUTPUT_D5_MASK;
	}
	
	if (GetOutputD6()) {
		status |= OUTPUT_D6_MASK;
	}
	
	if (GetOutputD7()) {
		status |= OUTPUT_D7_MASK;
	}
	
	return status;
}

uint8_t GetInputStatus(void) {
	uint8_t status = 0;
	
	if (GetInputD14()) {
		status |= INPUT_D14_MASK;
	}
	
	if (GetInputD15()) {
		status |= INPUT_D15_MASK;
	}
	
	if (GetInputD16()) {
		status |= INPUT_D16_MASK;
	}
	
	if (GetInputD17()) {
		status |= INPUT_D17_MASK;
	}
	
	if (GetInputD18()) {
		status |= INPUT_D18_MASK;
	}
	
	if (GetInputD19()) {
		status |= INPUT_D19_MASK;
	}
	
	if (GetInputD52()) {
		status |= INPUT_D52_MASK;
	}
	
	if (GetInputD53()) {
		status |= INPUT_D53_MASK;
	}
	
	return status;
}