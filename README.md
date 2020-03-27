# InputManager
Unity InputManager for multiple controllers at once (basic) 

## Setup 
load up the Input Setting (Project Settings>Input) 
![Preview](https://github.com/Aionmagan/InputManager/blob/master/SetupPreviews/Preview%20(2).png)

load in the InputManager.preset
![Preview](https://github.com/Aionmagan/InputManager/blob/master/SetupPreviews/Preview%20(1).png)

the InputManager.cs doesn't need and object 
just put it in Script>InputManager folder and it's ready to use 

## How to use
the InputManager.cs doesn't need and object or to exist in 
the Hierachy
just put it in Script>InputManager folder 

recommend using xbox 360 or xbox one controller

# Function calls 


## MainHorizontal(int controllerPort = 1)
    returns a float base on X axis (Horizontal) or 
    left analog stick X axis 

## MainVertical(int controllerPort = 1)    
    returns a float base on Y axis (Horizontal) or 
    left analog stick Y axis

## MainAxes(int controllerPort = 1, float diagonalLimitDivition = 1.5f)
    returns a vector base on both Horizontal and Vertical 
    with a limit divition for when Horizontal + Vertical || Left Analog = 0/2/-2
    Vector3(Horizontal, 0, Vertical)
    
## MainAxesIsActive(int controllerPort = 1)
    returns bool value on both Horizontal an Vertical or
    Left analog stick X/Y Axis (true if one of them is 0)

## SecondHorizontal(int controllerPort = 1)
    returns float base on MouseX(only controllerPort 1) or
    right analog stick X Axis

## SecondVertical(int controllerPort = 1)   
    returns float base on MouseY(only controllerPort 1) or
    right analog stick Y Axis
    SecondVertical(int controllerPort = 1)

## SecondAxes(int controllerPort = 1, float diagonalLimitDivition = 1.5f)  
    returns a vector base on both MouseX and MouseY (controllerPort 2 only) or 
    right analog stick X/Y Axis
    with a limit divition for when MouseX + MouseY || Right Analog = 0/2/-2
    Vector3(Horizontal, 0, Vertical)

## SecondAxesIsActive(int controllerPort = 1)
    returns bool value on both MouseX an MouseY(controllerPort 1 only) or
    Right analog stick X/Y Axis (true if one of them is 0)
        
## DpadHorizontal(int controllerPort = 1)        
    returns float value base on Dpad X Axis
 
## DpadVertical(int controllerPort = 1)
    returns float value base on Dpad Y Axis       

## Action0(Button button, int controllerPort = 1)
    returns bool value base on 
    Button.UP/Button.DOWN/Button.HOLD

## Action1(Button button, int controllerPort = 1)
    returns bool value base on 
    Button.UP/Button.DOWN/Button.HOLD

## Action2(Button button, int controllerPort = 1)
    returns bool value base on 
    Button.UP/Button.DOWN/Button.HOLD       

## Action3(Button button, int controllerPort = 1)
    returns bool value base on 
    Button.UP/Button.DOWN/Button.HOLD

## Action4(Button button, int controllerPort = 1)
    returns bool value base on 
    Button.UP/Button.DOWN/Button.HOLD        

## Action5(Button button, int controllerPort = 1)
    returns bool value base on 
    Button.UP/Button.DOWN/Button.HOLD

## Action6(Button button, int controllerPort = 1)
    returns bool value base on 
    Button.UP/Button.DOWN/Button.HOLD
      
## Action7(Button button, int controllerPort = 1)
    returns bool value base on 
    Button.UP/Button.DOWN/Button.HOLD

## Action8(Button button, int controllerPort = 1)
    returns bool value base on 
    Button.UP/Button.DOWN/Button.HOLD

## Action9(Button button, int controllerPort = 1)
    returns bool value base on 
    Button.UP/Button.DOWN/Button.HOLD

## LeftTrigger(int controllerPort = 1)
    returns bool value base on 
    Left Trigger 9 Axis

## RightTrigger(int controllerPort = 1)
    returns bool value base on 
    Right Trigger 10 Axis 

## Triggers(int controllerPort = 1)
    returns bool value base on
    Trigger 3 Axis


