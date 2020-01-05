/*
 * system_timer.h
 *
 * Created: 1/4/2020 5:19:25 PM
 *  Author: Matt
 */ 


#ifndef SYSTEM_TIMER_H_
#define SYSTEM_TIMER_H_

#include <stdint.h>
#include <stdbool.h>

void InitializeSystemTimer(void);
uint32_t GetSystemTimeMilliseconds(void);
bool HasXMillisecondsElapsed(uint32_t interval, uint32_t start_time);

#endif /* SYSTEM_TIMER_H_ */