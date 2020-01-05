/*
 * same70_gpio.c
 *
 * Created: 1/2/2020 9:25:24 PM
 *  Author: Matt
 */ 

#include "same70_gpio.h"
#include "ioport.h"
#include "same70_xplained.h"

//Stores output level
bool flagOutputD0;
bool flagOutputD1;
bool flagOutputD2;
bool flagOutputD3;
bool flagOutputD4;
bool flagOutputD5;
bool flagOutputD6;
bool flagOutputD7;
bool flagLED;

void InitializeIoPorts(void) {
	
	flagOutputD0 = 0;
	flagOutputD1 = 0;
	flagOutputD2 = 0;
	flagOutputD3 = 0;
	flagOutputD4 = 0;
	flagOutputD5 = 0;
	flagOutputD6 = 0;
	flagOutputD7 = 0;
	flagLED = 0;
	
	//Configure outputs
	ioport_set_pin_dir(OUTPUT_D0, IOPORT_DIR_OUTPUT);
	ioport_set_pin_level(OUTPUT_D0, IOPORT_PIN_LEVEL_LOW);
	
	ioport_set_pin_dir(OUTPUT_D1, IOPORT_DIR_OUTPUT);
	ioport_set_pin_level(OUTPUT_D1, IOPORT_PIN_LEVEL_LOW);
	
	ioport_set_pin_dir(OUTPUT_D2, IOPORT_DIR_OUTPUT);
	ioport_set_pin_level(OUTPUT_D2, IOPORT_PIN_LEVEL_LOW);
	
	ioport_set_pin_dir(OUTPUT_D3, IOPORT_DIR_OUTPUT);
	ioport_set_pin_level(OUTPUT_D3, IOPORT_PIN_LEVEL_LOW);
	
	ioport_set_pin_dir(OUTPUT_D4, IOPORT_DIR_OUTPUT);
	ioport_set_pin_level(OUTPUT_D4, IOPORT_PIN_LEVEL_LOW);
	
	ioport_set_pin_dir(OUTPUT_D5, IOPORT_DIR_OUTPUT);
	ioport_set_pin_level(OUTPUT_D5, IOPORT_PIN_LEVEL_LOW);
	
	ioport_set_pin_dir(OUTPUT_D6, IOPORT_DIR_OUTPUT);
	ioport_set_pin_level(OUTPUT_D6, IOPORT_PIN_LEVEL_LOW);
	
	ioport_set_pin_dir(OUTPUT_D7, IOPORT_DIR_OUTPUT);
	ioport_set_pin_level(OUTPUT_D7, IOPORT_PIN_LEVEL_LOW);
	
	//Configure LED, technically an output
	ioport_set_pin_dir(LED0_GPIO, IOPORT_DIR_OUTPUT);
	ioport_set_pin_level(LED0_GPIO, IOPORT_PIN_LEVEL_LOW);
	
	
	//Configure inputs
	//Pins D14-D17 will be pull-downs
	//These are normally 0V and will return low (0)
	//Returns high (1) when voltage above 1.5V is sensed
	ioport_set_pin_dir(INPUT_D14, IOPORT_DIR_INPUT);
	ioport_set_pin_mode(INPUT_D14, IOPORT_MODE_PULLDOWN);
	
	ioport_set_pin_dir(INPUT_D15, IOPORT_DIR_INPUT);
	ioport_set_pin_mode(INPUT_D15, IOPORT_MODE_PULLDOWN);
	
	ioport_set_pin_dir(INPUT_D16, IOPORT_DIR_INPUT);
	ioport_set_pin_mode(INPUT_D16, IOPORT_MODE_PULLDOWN);
	
	ioport_set_pin_dir(INPUT_D17, IOPORT_DIR_INPUT);
	ioport_set_pin_mode(INPUT_D17, IOPORT_MODE_PULLDOWN);
	
	//Pins D18, D19, D52, and D53 will be pull-ups
	//These are normally 3.3V and return high (1)
	//Returns low (0) when pin is grounded or voltage drops below 1.5V
	ioport_set_pin_dir(INPUT_D18, IOPORT_DIR_INPUT);
	ioport_set_pin_mode(INPUT_D18, IOPORT_MODE_PULLUP);
	
	ioport_set_pin_dir(INPUT_D19, IOPORT_DIR_INPUT);
	ioport_set_pin_mode(INPUT_D19, IOPORT_MODE_PULLUP);
	
	ioport_set_pin_dir(INPUT_D52, IOPORT_DIR_INPUT);
	ioport_set_pin_mode(INPUT_D52, IOPORT_MODE_PULLUP);
	
	ioport_set_pin_dir(INPUT_D53, IOPORT_DIR_INPUT);
	ioport_set_pin_mode(INPUT_D53, IOPORT_MODE_PULLUP);
}

//Setters for outputs
//only write to pin if value is different
void SetOutputD0(bool on) {
	if (on != flagOutputD0) {
		ioport_set_pin_level(OUTPUT_D0, on);
		flagOutputD0 = on;
	}
}
void SetOutputD1(bool on) {
	if (on != flagOutputD1) {
		ioport_set_pin_level(OUTPUT_D1, on);
		flagOutputD1 = on;
	}
}

void SetOutputD2(bool on) {
	if (on != flagOutputD2) {
		ioport_set_pin_level(OUTPUT_D2, on);
		flagOutputD2 = on;
	}
}

void SetOutputD3(bool on) {
	if (on != flagOutputD3) {
		ioport_set_pin_level(OUTPUT_D3, on);
		flagOutputD3 = on;
	}
}

void SetOutputD4(bool on) {
	if (on != flagOutputD4) {
		ioport_set_pin_level(OUTPUT_D4, on);
		flagOutputD4 = on;
	}
}

void SetOutputD5(bool on) {
	if (on != flagOutputD5) {
		ioport_set_pin_level(OUTPUT_D5, on);
		flagOutputD5 = on;
	}
}

void SetOutputD6(bool on) {
	if (on != flagOutputD6) {
		ioport_set_pin_level(OUTPUT_D6, on);
		flagOutputD6 = on;
	}
}

void SetOutputD7(bool on) {
	if (on != flagOutputD7) {
		ioport_set_pin_level(OUTPUT_D7, on);
		flagOutputD7 = on;
	}
}

void ToggleLED(void) {
	if (flagLED) {
		ioport_set_pin_level(LED0_GPIO, false);
		flagLED = false;
	}
	else {
		ioport_set_pin_level(LED0_GPIO, true);
		flagLED = true;
	}
	
}

//Getters for outputs
bool GetOutputD0(void) {
	return flagOutputD0;
}

bool GetOutputD1(void) {
	return flagOutputD1;
}

bool GetOutputD2(void) {
	return flagOutputD2;
}

bool GetOutputD3(void) {
	return flagOutputD3;
}
bool GetOutputD4(void) {
	return flagOutputD4;
}

bool GetOutputD5(void) {
	return flagOutputD5;
}

bool GetOutputD6(void) {
	return flagOutputD6;
}

bool GetOutputD7(void) {
	return flagOutputD7;
}

//Getters for pull-down inputs
bool GetInputD14(void) {
	return ioport_get_pin_level(INPUT_D14);
}

bool GetInputD15(void) {
	return ioport_get_pin_level(INPUT_D15);
}
bool GetInputD16(void) {
	return ioport_get_pin_level(INPUT_D16);
}

bool GetInputD17(void) {
	return ioport_get_pin_level(INPUT_D17);
}


//Getters for pull-up inputs
//logic is inverted since pins are normally high instead of low
bool GetInputD18(void) {
	return !ioport_get_pin_level(INPUT_D18);
}

bool GetInputD19(void) {
	return !ioport_get_pin_level(INPUT_D19);
}

bool GetInputD52(void) {
	return !ioport_get_pin_level(INPUT_D52);
}

bool GetInputD53(void) {
	return !ioport_get_pin_level(INPUT_D53);
}