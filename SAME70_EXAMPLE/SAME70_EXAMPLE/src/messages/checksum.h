
/*
* checksum.h
*
* Created: 1/8/2020 9:39:45 PM
*  Author: Matt
*/

#include <stdint.h>

#ifdef __cplusplus
extern "C" {
	#endif

	uint16_t calculate_checksum(uint8_t *bytes, uint32_t size);

	#ifdef __cplusplus
};
#endif