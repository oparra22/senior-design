//most recent code trying to figure out pin testing
/*******************************************************
This program was created by the CodeWizardAVR V3.24 
Automatic Program Generator
© Copyright 1998-2015 Pavel Haiduc, HP InfoTech s.r.l.
http://www.hpinfotech.com

Project : GCI IC Tester 
Version : 4
Date    : 4/7/2017
Author  : Kommon Ousley, Karl Farhat
Company : Engineered Aggression
Comments:   This Program DOES work. It will test a pin correctly
and send it back to the GUI - both with the USB and RS232 Cables. 
Use this with the most updated GUI.(receives a buffer of 3 bytes)

Chip type               : ATmega16
Program type            : Application
AVR Core Clock frequency: 3.680000 MHz
Memory model            : Small
External RAM size       : 0
Data Stack size         : 256
*******************************************************/
#include <stdio.h>
#include <avr/io.h>
#include <main.h> //Our manually created header file
#include <delay.h>
//#include <string.h>
#include <avr/interrupt.h>
//#include <avr/pgmspace.h>
//#include <ff.h>
//#include <avr/io.h>


#define RXB8 1
#define TXB8 0
#define UPE 2
#define OVR 3
#define FE 4
//#define UDRE 5 //was 5
#define RXC 7

#define FRAMING_ERROR (1<<FE)
#define PARITY_ERROR (1<<UPE)
#define DATA_OVERRUN (1<<OVR)
#define DATA_REGISTER_EMPTY (1<<UDRE)
#define RX_COMPLETE (1<<RXC)
int c = 0;
int adc_data[];
volatile unsigned char CommandBuffer[RX_BUFFER_SIZE];
volatile unsigned char CommandBufferPtr = 0;
unsigned char pin1 = 0;
unsigned char pin2 = 0;


//This is the pin under test, 
volatile unsigned int PinUnderTest = 0;
//don't think we will need this
//volatile unsigned char CurrentADChannel = AD_NORMALDIODE;
#define ADC_VREF_TYPE ((0<<REFS1) | (0<<REFS0) | (0<<ADLAR))

//static FILE mystdout = FDEV_SETUP_STREAM(UART_putchar, NULL, _FDEV_SETUP_WRITE);
//
//
static int WriteChar(unsigned char c)
{
    while ((UCSRA & (1 << UDRE)) == 0) {}; // Do nothing until UDR is ready for more data to be written to it

    UDR = c;
    
    return 0;
}

static int UART_putchar(unsigned char c)
{
    //if (c == '\n') UART_putchar('\r', stream);
//  
//    while ((UCSRA & (1 << UDRE)) == 0) {}; // Do nothing until UDR is ready for more data to be written to it
//
//    UDR = c;
//    
//    return 0;
 while ((UCSRA & (1 << UDRE)) == 0) {}; // Do nothing until UDR is ready for more data to be written to it

    UDR = c;
    
    return 0;
}

unsigned char GetChannel(unsigned char pin)
{

    return ((pin-1)%32)/2;
}

void SetPair(unsigned int pin)
{


 if(pin > 256)
 {
    // PORTC.1 = 0;   
     //PORTC.3 = 0;
 }                  
 else if (pin < 256){
    //PORTC.0 = 0;  
  //PORTC.4 = 0;
 }

}
void SetMUXs(unsigned char PinID)
{
    int odd = (int)PinID % 2; 
    if(odd)
    {        
        ADMUX = 0x00; //works
        PORTB = GetChannel(PinID);
    }  
    //else even
    else{   
        ADMUX=0x01; //works
        PORTB = GetChannel(PinID) < 4;
    }   
    
   

}



void InitCommandBuffer()
{

    for (c = 0;c < 6;c++)
    {
        CommandBuffer[c] = 0;
    }
    CommandBufferPtr = 0;
}
//try rxc and rxcie
interrupt [USART_RXC] void usart_rx_isr(void)
{

unsigned char input = UDR;

//PORTC.7 = 0;
    if (input == 255)
    {
        InitCommandBuffer(); 
        PORTC.4=0;   
        PORTC.5 = 1;
        return;
    }
   
    if (CommandBufferPtr < RX_BUFFER_SIZE)
    {      
        //CommandBufferPtr++;
        CommandBuffer[CommandBufferPtr++] = input; 
        PORTC = !CommandBufferPtr;  
        PORTC.4 = 1;
    }
    else
    {
        InitCommandBuffer();
        PORTC.6 = 0;  
        PORTC.5 = 1;
    }  
     
    
}
interrupt [ADC_INT] void adc_isr(void)
{
volatile unsigned int adc_data;
//PORTC.4=0;
// Read the AD conversion result

adc_data=ADCW;

// Place your code here
    PORTC.0 = 0;
    WriteChar('R');
    //WriteChar(PinUnderTest); 
    PORTC.0 = 0; 
    WriteChar(pin1); 
    WriteChar(pin2);
    PORTC.1 = 0;
    WriteChar(adc_data >> 8);
    PORTC.2 = 0;
    WriteChar(adc_data);
    PORTC.3 = 0;
    WriteChar((unsigned char)255);
    PORTC.4 = 0;
    WriteChar((unsigned char)255);
    PORTC.5 = 1;
    //delay_ms(1000);
//PORTC.6 = 0;
//ADCSRA |= (0 << ADSC); //Experimental line to get one reading.
}

void RequestADConversion()
{
   ADCSRA |= (1 << ADSC);  // Enable ADC  
   //delay_ms(50);
}


//The original code does not have this as a void, maybe it returns a 0 and lets the GUI know it is done working
void main(void)

//int pinToTest;
                                                                                                  
{
    // Port A initialization
    // Function: Bit7=In Bit6=In Bit5=In Bit4=In Bit3=In Bit2=In Bit1=In Bit0=In 
    DDRA=(0<<DDA7) | (0<<DDA6) | (0<<DDA5) | (0<<DDA4) | (0<<DDA3) | (0<<DDA2) | (0<<DDA1) | (0<<DDA0);
    // State: Bit7=T Bit6=T Bit5=T Bit4=T Bit3=T Bit2=T Bit1=T Bit0=T 
    PORTA=(0<<PORTA7) | (0<<PORTA6) | (0<<PORTA5) | (0<<PORTA4) | (0<<PORTA3) | (0<<PORTA2) | (0<<PORTA1) | (0<<PORTA0);

    // Port B initialization
    // Function: Bit7=Out Bit6=Out Bit5=Out Bit4=Out Bit3=Out Bit2=Out Bit1=Out Bit0=Out 
    DDRB=(1<<DDB7) | (1<<DDB6) | (1<<DDB5) | (1<<DDB4) | (1<<DDB3) | (1<<DDB2) | (1<<DDB1) | (1<<DDB0);
    // State: Bit7=1 Bit6=1 Bit5=1 Bit4=1 Bit3=1 Bit2=1 Bit1=1 Bit0=1 
    PORTB=(1<<PORTB7) | (1<<PORTB6) | (1<<PORTB5) | (1<<PORTB4) | (1<<PORTB3) | (1<<PORTB2) | (1<<PORTB1) | (1<<PORTB0);

    // Port C initialization
    // Function: Bit7=Out Bit6=Out Bit5=Out Bit4=Out Bit3=Out Bit2=Out Bit1=Out Bit0=Out 
    DDRC=(1<<DDC7) | (1<<DDC6) | (1<<DDC5) | (1<<DDC4) | (1<<DDC3) | (1<<DDC2) | (1<<DDC1) | (1<<DDC0);
    // State: Bit7=T Bit6=T Bit5=T Bit4=T Bit3=T Bit2=T Bit1=T Bit0=T 
    PORTC=(1<<PORTC7) | (1<<PORTC6) | (1<<PORTC5) | (1<<PORTC4) | (1<<PORTC3) | (1<<PORTC2) | (1<<PORTC1) | (1<<PORTC0);

    // Port D initialization
    // Function: Bit7=In Bit6=In Bit5=In Bit4=In Bit3=In Bit2=In Bit1=In Bit0=In 
    DDRD=(0<<DDD7) | (0<<DDD6) | (0<<DDD5) | (0<<DDD4) | (0<<DDD3) | (0<<DDD2) | (0<<DDD1) | (0<<DDD0);
    // State: Bit7=T Bit6=T Bit5=T Bit4=T Bit3=T Bit2=T Bit1=T Bit0=T 
    PORTD=(0<<PORTD7) | (0<<PORTD6) | (0<<PORTD5) | (0<<PORTD4) | (0<<PORTD3) | (0<<PORTD2) | (0<<PORTD1) | (0<<PORTD0);

    // Timer/Counter 0 initialization
    // Clock source: System Clock
    // Clock value: Timer 0 Stopped
    // Mode: Normal top=0xFF
    // OC0 output: Disconnected
    TCCR0=(0<<WGM00) | (0<<COM01) | (0<<COM00) | (0<<WGM01) | (0<<CS02) | (0<<CS01) | (0<<CS00);
    TCNT0=0x00;
    OCR0=0x00;


    // Timer(s)/Counter(s) Interrupt(s) initialization
    TIMSK=(0<<OCIE2) | (0<<TOIE2) | (0<<TICIE1) | (0<<OCIE1A) | (0<<OCIE1B) | (0<<TOIE1) | (0<<OCIE0) | (0<<TOIE0);

    // External Interrupt(s) initialization
    // INT0: Off
    // INT1: Off
    // INT2: Off
    MCUCR=(0<<ISC11) | (0<<ISC10) | (0<<ISC01) | (0<<ISC00);
    MCUCSR=(0<<ISC2);

    // USART initialization
    // Communication Parameters: 8 Data, 1 Stop, No Parity
    // USART Receiver: On
    // USART Transmitter: On          
    // USART Mode: Asynchronous
    // USART Baud Rate: 9600
//    UCSRA=(0<<RXC) | (0<<TXC) | (0<<UDRE) | (0<<FE) | (0<<DOR) | (0<<UPE) | (0<<U2X) | (0<<MPCM);
//    UCSRB=(0<<RXCIE) | (0<<TXCIE) | (0<<UDRIE) | (1<<RXEN) | (1<<TXEN) | (0<<UCSZ2) | (0<<RXB8) | (0<<TXB8);
//    UCSRC=(1<<URSEL) | (0<<UMSEL) | (0<<UPM1) | (0<<UPM0) | (0<<USBS) | (1<<UCSZ1) | (1<<UCSZ0) | (0<<UCPOL);
//    UBRRH=0x00;
//    UBRRL=0x17;
UCSRA=(0<<RXC) | (0<<TXC) | (0<<UDRE) | (0<<FE) | (0<<DOR) | (0<<UPE) | (0<<U2X) | (0<<MPCM);
UCSRB=(1<<RXCIE) | (1<<TXCIE) | (0<<UDRIE) | (1<<RXEN) | (1<<TXEN) | (0<<UCSZ2) | (0<<RXB8) | (0<<TXB8);
UCSRC=(1<<URSEL) | (0<<UMSEL) | (0<<UPM1) | (0<<UPM0) | (0<<USBS) | (1<<UCSZ1) | (1<<UCSZ0) | (0<<UCPOL);
UBRRH=0x00;
UBRRL=0x17;
//UBRRH=BAUD_PRESCALE >> 8;
//UBRRL=BAUD_PRESCALE;
//stdout = &mystdout; //Required for printf init

//was UBRRRL=0x33;

    // Analog Comparator initialization
    // Analog Comparator: Off
    // The Analog Comparator's positive input is
    // connected to the AIN0 pin
    // The Analog Comparator's negative input is
    // connected to the AIN1 pin
    ACSR=(1<<ACD) | (0<<ACBG) | (0<<ACO) | (0<<ACI) | (0<<ACIE) | (0<<ACIC) | (0<<ACIS1) | (0<<ACIS0);

    // ADC initialization
    // ADC Clock frequency: 920.000 kHz
    // ADC Voltage Reference: AREF pin
    // ADC Auto Trigger Source: Free Running
//    ADMUX=ADC_VREF_TYPE;
//    ADCSRA=(1<<ADEN) | (0<<ADSC) | (1<<ADATE) | (0<<ADIF) | (1<<ADIE) | (0<<ADPS2) | (1<<ADPS1) | (0<<ADPS0);
//    SFIOR=(0<<ADTS2) | (0<<ADTS1) | (0<<ADTS0);

// ADC initialization
// ADC Clock frequency: 125.000 kHz
// ADC Voltage Reference: AREF pin
// ADC Auto Trigger Source: ADC Stopped
ADMUX=ADC_VREF_TYPE;
ADCSRA=(1<<ADEN) | (0<<ADSC) | (0<<ADATE) | (0<<ADIF) | (1<<ADIE) | (1<<ADPS2) | (1<<ADPS1) | (0<<ADPS0);
SFIOR=(0<<ADTS2) | (0<<ADTS1) | (0<<ADTS0);
    // SPI initialization
    // SPI disabled
    SPCR=(0<<SPIE) | (0<<SPE) | (0<<DORD) | (0<<MSTR) | (0<<CPOL) | (0<<CPHA) | (0<<SPR1) | (0<<SPR0);

    // TWI initialization
    // TWI disabled
    TWCR=(0<<TWEA) | (0<<TWSTA) | (0<<TWSTO) | (0<<TWEN) | (0<<TWIE);

    // Globally enable interrupts
    #asm("sei")
    //sei();
    //USART0_init();
    //ADC_init();
    //InitResultDisplay();
    //InitMuxControl();
    //InitMuxTestChannels();
    
    #asm("sei")
    InitCommandBuffer();
    
    
    while (1)
    {      
    
    
        
       
        if (CommandBufferPtr >= 3)
        {       
         
            switch (CommandBuffer[0])
            {   
            //PORTC.7 = 1;
                case 'T':   
                    //PinUnderTest = CommandBuffer[1] +  CommandBuffer[2]; 
                    PORTC.7 = 0; 
                    //delay_ms(1000);
                    pin1 = CommandBuffer[1];
                    pin2 = CommandBuffer[2];
                    PinUnderTest = pin1 + pin2;
                    SetMUXs(PinUnderTest);
                    SetPair(PinUnderTest);
                    //delay_ms(50);
                    RequestADConversion();
                    
                    break;
                case 'G':
                    //RESULT_FAIL_OFF;
                    //RESULT_PASS_ON;
                    break;
                case 'B':
                    //RESULT_FAIL_ON;
                    //RESULT_PASS_OFF;
                    break;
                case 255:
                    InitCommandBuffer();
                    break;
                default:
                    InitCommandBuffer();
                    break;
            
            }
            
            InitCommandBuffer();
        }
    }
    //return 0;
}