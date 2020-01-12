/*
* message_defines.h
*
* Created: 1/2/2020 11:31:16 PM
*  Author: Matt
*/


#ifndef MESSAGE_DEFINES_H_
#define MESSAGE_DEFINES_H_

//assign each output to a bit
//will pack all 8 outputs into a single byte
#define OUTPUT_D0_MASK 0x1
#define OUTPUT_D1_MASK 0x2
#define OUTPUT_D2_MASK 0x4
#define OUTPUT_D3_MASK 0x8
#define OUTPUT_D4_MASK 0x10
#define OUTPUT_D5_MASK 0x20
#define OUTPUT_D6_MASK 0x40
#define OUTPUT_D7_MASK 0x80

#define OUTPUT_D0_SHIFT 0
#define OUTPUT_D1_SHIFT 1
#define OUTPUT_D2_SHIFT 2
#define OUTPUT_D3_SHIFT 3
#define OUTPUT_D4_SHIFT 4
#define OUTPUT_D5_SHIFT 5
#define OUTPUT_D6_SHIFT 6
#define OUTPUT_D7_SHIFT 7

//assign each input to a bit
//will pack all 8 inputs into a single byte
#define INPUT_D14_MASK 0x1
#define INPUT_D15_MASK 0x2
#define INPUT_D16_MASK 0x4
#define INPUT_D17_MASK 0x8
#define INPUT_D18_MASK 0x10
#define INPUT_D19_MASK 0x20
#define INPUT_D52_MASK 0x40
#define INPUT_D53_MASK 0x80

#define INPUT_D14_SHIFT 0
#define INPUT_D15_SHIFT 1
#define INPUT_D16_SHIFT 2
#define INPUT_D17_SHIFT 3
#define INPUT_D18_SHIFT 4
#define INPUT_D19_SHIFT 5
#define INPUT_D52_SHIFT 6
#define INPUT_D53_SHIFT 7

//message header bytes
#define HEADER_BYTE_1 0x41 //A
#define HEADER_BYTE_2 0x53 //S
#define HEADER_BYTE_3 0x37 //7
#define HEADER_BYTE_4 0x30 //0

//message ID's
#define STATUS_MESSAGE_ID 100
#define CONTROL_MESSAGE_ID 200

//message sizes (bytes)
#define STATUS_MESSAGE_SIZE 10
#define CONTROL_MESSAGE_SIZE 9

//used to send state of board to client
#pragma pack(push, 1)
struct StatusMessage {
	uint8_t header_byte1;
	uint8_t header_byte2;
	uint8_t header_byte3;
	uint8_t header_byte4;
	uint8_t msg_id;
	uint8_t msg_size;
	uint8_t output_status;
	uint8_t input_status;
	uint16_t checksum;	
};
#pragma pack(pop)

//message from client to change state of IO's
#pragma pack(push, 1)
struct ControlMessage {
	uint8_t header_byte1;
	uint8_t header_byte2;
	uint8_t header_byte3;
	uint8_t header_byte4;
	uint8_t msg_id;
	uint8_t msg_size;
	uint8_t output_status;
	uint16_t checksum;
};
#pragma pack(pop)

#endif /* MESSAGE_DEFINES_H_ */