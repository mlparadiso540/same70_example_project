/*
 * udp_comms.h
 *
 * Created: 1/4/2020 7:54:06 PM
 *  Author: Matt
 */ 


#ifndef UDP_COMMS_H_
#define UDP_COMMS_H_

#include <stdint.h>

int init_udp_comms(void);
void udp_task(void);
void SendStatusMessage(void);
void ParseOutputControl(uint8_t outputs);
//Populates input/output status into a single byte
uint8_t GetOutputStatus(void);
uint8_t GetInputStatus(void);




#endif /* UDP_COMMS_H_ */