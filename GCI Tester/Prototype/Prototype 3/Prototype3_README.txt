This file discusses the 3rd prototype for the embedded firmware. This system is able to transmit a signal to the microcontroller from the GUI. In this prototype, the LEDs on the STK500 turn on when it receives an interrupt. The LEDs are turned on in the RX interrupt service Routine.

Update 3.1:
3.1 has a little bit of adjusted code so that it may correctly choose the right channel on ONE mux. This version does not factor in whether the pin is even or odd, It simply acts as the other system where it will choose the correct pin number up to 16 pins. 
