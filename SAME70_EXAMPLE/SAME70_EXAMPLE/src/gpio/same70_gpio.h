/*
* same70_gpio.h
*
* Created: 1/2/2020 9:25:38 PM
*  Author: Matt
*/


#ifndef SAME70_GPIO_H_
#define SAME70_GPIO_H_

#include <stdbool.h>

#ifdef __cplusplus
extern "C" {
	#endif

	//Outputs - header J503
	#define OUTPUT_D0 PIO_PD28_IDX
	#define OUTPUT_D1 PIO_PD30_IDX
	#define OUTPUT_D2 PIO_PA5_IDX
	#define OUTPUT_D3 PIO_PA6_IDX
	#define OUTPUT_D4 PIO_PD27_IDX
	#define OUTPUT_D5 PIO_PD11_IDX
	#define OUTPUT_D6 PIO_PC19_IDX
	#define OUTPUT_D7 PIO_PA2_IDX

	//Inputs - Header J505
	#define INPUT_D14 PIO_PB1_IDX
	#define INPUT_D15 PIO_PB0_IDX
	#define INPUT_D16 PIO_PD16_IDX
	#define INPUT_D17 PIO_PD15_IDX
	#define INPUT_D18 PIO_PD19_IDX
	#define INPUT_D19 PIO_PD18_IDX

	//bottom two pins are duplicates from J503
	//use ports from J507 instead (2x18 header)
	#define INPUT_D52 PIO_PC12_IDX
	#define INPUT_D53 PIO_PC14_IDX

	//initializes all inputs and outputs
	void InitializeIoPorts(void);

	//Setters for output IO's
	void SetOutputD0(bool on);
	void SetOutputD1(bool on);
	void SetOutputD2(bool on);
	void SetOutputD3(bool on);
	void SetOutputD4(bool on);
	void SetOutputD5(bool on);
	void SetOutputD6(bool on);
	void SetOutputD7(bool on);
	void ToggleLED(void);

	//Getters for outputs
	bool GetOutputD0(void);
	bool GetOutputD1(void);
	bool GetOutputD2(void);
	bool GetOutputD3(void);
	bool GetOutputD4(void);
	bool GetOutputD5(void);
	bool GetOutputD6(void);
	bool GetOutputD7(void);

	//Getters for inputs
	bool GetInputD14(void);
	bool GetInputD15(void);
	bool GetInputD16(void);
	bool GetInputD17(void);
	bool GetInputD18(void);
	bool GetInputD19(void);
	bool GetInputD52(void);
	bool GetInputD53(void);	
	
	#ifdef __cplusplus
};
#endif




#endif /* SAME70_GPIO_H_ */