
/*
 * checksum.c
 *
 * Created: 1/8/2020 9:39:59 PM
 *  Author: Matt
 */ 

#include "checksum.h"

uint16_t calculate_checksum(uint8_t *bytes, uint32_t size) {
	uint16_t checksum = 0;
	
	for(int i = 0; i < (size - 2); i++) {
		checksum += (uint8_t)bytes[i];
	}
	
	return checksum;
}