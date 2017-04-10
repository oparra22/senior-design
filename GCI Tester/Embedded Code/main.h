#define RX_BUFFER_SIZE 6
//PORT A, Free Pins = 2-5
#define FAILED_LED 			PORTA.0
#define PASSED_LED 			PORTA.1
#define ADC_A 				PORTA.6	
#define ADC_B 				PORTA.7

//PORT B, Free Pins = None, DD_MUXTESTCHANNELS Might not be used
#define DD_MUXTESTCHANNELS 	DDRB
#define PORT_RESULTS		PORTB

//PORT C, Free Pins = 7
//Titled PORT and DD MUXENABLES because this port handles all of the 
//Enable bits that are sent to the 3x8 muxes which determine which 
//pairs of A and B muxes are to be used
#define DD_MUXENABLES		DDRC
#define PORT_MUXENABLES		PORTC

//PORT D , Free pins = 5,6,7 , 
#define RX_PIN				PORTD.0
#define TX_PIN				PORTD.1
#define R0					PORTD.2
#define R1					PORTD.3
#define R2					PORTD.4
