/*
* system_timer.c
*
* Used to keep track of time since powered on (milliseconds)
*
* Created: 1/4/2020 5:19:14 PM
*  Author: Matt
*/

#include "system_timer.h"
#include "sysclk.h"

volatile uint32_t system_time_ms = 0; //milliseconds since powered on

void SysTick_Handler(void)
{
	system_time_ms++;
	if (system_time_ms == UINT32_MAX) {
		//prevent overflow
		//roughly 49.7 days of on-time
		system_time_ms = 0;
	}
}

void InitializeSystemTimer(void) 
{
	//Configure to hit SysTick_Hanlder every one millisecond
	SysTick_Config(sysclk_get_cpu_hz() / 1000);
}

/* returns the number of milliseconds since board was powered on */
uint32_t GetSystemTimeMilliseconds(void) {
	return system_time_ms;
}

/* checks if <interval> milliseconds has elapsed since <start_time> */
bool HasXMillisecondsElapsed(uint32_t interval, uint32_t start_time) {
	return ((system_time_ms - start_time) > interval);
}
