/*
 * custom manager using enum states for no mistake checking 
 * to use this Inputmanager simply add the 'using Inputmanager' 
 * to your script and call each function like so 
 * 'Controller.FUNCTION(Button.STATES); where FUCNTION is replaced 
 * with the function needed, STATES if it's a parameter is either 
 * HOLD, DOWN, UP (Button.HOLD) 
 */

using UnityEngine;

namespace InputManager
{
    enum Button
    {
        HOLD,
        DOWN, 
        UP
    }
    static class Controller
    {
        //check Controller port limitation
        private static bool ControllerPortValid(in int controllerPort)
        {
            if (controllerPort < 1 || controllerPort > 4)
            {
                Debug.LogError($"Controller port set to {controllerPort}, invalid controller port, select port 1 - 4");
                return false;
            }
            return true;
        }

        // Axes Functions 

        /// <summary>
        /// returns float value from "Project Settings > input
        /// Left_Analog_X- + controllerPort
        /// </summary>
        /// <param name="controllerPort"></param>
        /// <returns>returns float value based on Left analog Horizontal movement</returns>
        public static float MainHorizontal(in int controllerPort = 1)
        {
            if (!ControllerPortValid(controllerPort)) { return 0; }
            return Input.GetAxis("Left_Analog_X-" + controllerPort.ToString());
        }

        /// <summary>
        /// returns float value from "Project Settings > input
        /// Left_Analog_Y- + controllerPort
        /// </summary>
        /// <param name="controllerPort"></param>
        /// <returns>returns float value based on Left analog Vertical movement</returns>
        public static float MainVertical(in int controllerPort = 1)
        {
            if (!ControllerPortValid(controllerPort)) { return 0; }
            return Input.GetAxis("Left_Analog_Y-" + controllerPort.ToString());
        }

        /// <summary>
        /// returns Vector(Hortizontal, 0, Vertical) "Project Setting > input
        /// Left_Analog_X- + controllerPort
        /// Left_Analog_y- + controllerPort//
        /// </summary>
        /// <param name="controllerPort"></param>
        /// <param name="diagonalLimitDivition"></param>
        /// <returns>returns vector3 value based on overall Left analog moment</returns>
        public static Vector3 MainAxes(in int controllerPort = 1, in float diagonalLimitDivition = 1.5f)
        {
            if (!ControllerPortValid(controllerPort)) { return Vector3.zero; }

            float limitHorizontal = MainHorizontal(controllerPort);
            float limitVertical = MainVertical(controllerPort);

            if (limitHorizontal + limitVertical == 0f || 
                limitHorizontal + limitVertical == 2f ||
                limitHorizontal + limitVertical == -2f)
            {
                limitHorizontal = (limitHorizontal / diagonalLimitDivition) ;
                limitVertical = (limitVertical / diagonalLimitDivition);
            }

            return new Vector3(limitHorizontal, 0, limitVertical);
        }

        /// <summary>
        /// returns boolean "Project Setting> Input
        /// based on analogs value
        /// Left_Analog_X- + controllerPort
        /// Left_Analog_Y- + controllerPort
        /// </summary>
        /// <param name="controllerPort"></param>
        /// <returns>returns true if value on Left analog is not 0</returns>
        public static bool MainAxesIsActive(in int controllerPort = 1)
        {
            if (!ControllerPortValid(controllerPort)) { return false; }
            //return (MainVertical(controllerPort) + MainHorizontal(controllerPort) != 0);
            //doesn't work because 1 + -1 = 0 but the sticks should be consider 'true' 

            if (MainVertical(controllerPort) != 0) { return true; }
            if (MainHorizontal(controllerPort) != 0) { return true; }

            return false;
        }

        /// <summary>
        /// returns float value from "Project Settings > input
        /// Mouse X (only controllerPort 1)
        /// Right_Analog_X- + controllerPort
        /// </summary>
        /// <param name="controllerPort"></param>
        /// <returns>returns float value based on Right analog Horizontal movement</returns>
        public static float SecondHorizontal(in int controllerPort = 1)
        {
            if (!ControllerPortValid(controllerPort)) { return 0; }

            if (controllerPort == 1)
            {
                return Mathf.Clamp(Input.GetAxis("Mouse X") +
                                   Input.GetAxis("Right_Analog_X-" + controllerPort.ToString()), -1.0f, 1.0f);
            }

            return Input.GetAxis("Right_Analog_X-" + controllerPort);
        }

        /// <summary>
        /// returns float value from "Project Settings > input
        /// Mouse Y (only controllerPort 1)
        /// Right_Analog_Y- + controllerPort
        /// </summary>
        /// <param name="controllerPort"></param>
        /// <returns>returns float value based on Right analog Vertical movement</returns>
        public static float SecondVertical(in int controllerPort = 1)
        {
            if (!ControllerPortValid(controllerPort)) { return 0; }

            if (controllerPort == 1)
            {
                return Mathf.Clamp(Input.GetAxis("Mouse Y") +
                                   Input.GetAxis("Right_Analog_Y-" + controllerPort.ToString()), -1.0f, 1.0f);
            }

            return Input.GetAxis("Right_Analog_Y-" + controllerPort.ToString());
        }

        /// <summary>
        /// returns float value from "Project Settings > input
        /// Mouse Y/X (only controllerPort 1)
        /// Right_Analog_Y- + controllerPort
        /// RIght_Analog_X- + controllerPort
        /// </summary>
        /// <param name="controllerPort"></param>
        /// <returns>returns float value based on overall Right analog movement</returns>
        public static Vector3 SecondAxes(in int controllerPort = 1, in float diagonalLimitDivition = 1.5f)
        {
            if (!ControllerPortValid(controllerPort)) { return Vector3.zero; }

            float limitHorizontal = SecondHorizontal(controllerPort);
            float limitVertical = SecondVertical(controllerPort);

            if (limitHorizontal + limitVertical == 0f ||
                limitHorizontal + limitVertical == 2f ||
                limitHorizontal + limitVertical == -2f)
            {
                limitHorizontal = (limitHorizontal / diagonalLimitDivition);
                limitVertical = (limitVertical / diagonalLimitDivition);
            }

            return new Vector3(limitHorizontal, 0, limitVertical);
        }

        /// <summary>
        /// returns boolean "Project Setting> Input
        /// based on analogs value
        /// Right_Analog_X- + controllerPort
        /// Right_Analog_Y- + controllerPort
        /// </summary>
        /// <param name="controllerPort"></param>
        /// <returns>returns true if value on Right analog is not 0</returns>
        public static bool SecondAxesIsActive(in int controllerPort = 1)
        {
            if (!ControllerPortValid(controllerPort)) { return false; }
            //return (SecondHorizontal(controllerPort) + SecondVertical(controllerPort) != 0);
            //doesn't work because 1 + -1 = 0 but the sticks should be consider 'true' 

            if (SecondVertical(controllerPort) != 0) { return true; }
            if (SecondHorizontal(controllerPort) != 0) { return true; }

            return false;
        }

        /// <summary>
        /// returns float value "Project Setting> Input
        /// based on Dpad value
        /// Dpad_X- + controllerPort
        /// </summary>
        /// <param name="controllerPort"></param>
        /// <returns>returns float depending on Dpad horizontal</returns>
        public static float DpadHorizontal(in int controllerPort = 1)
        {
            if (!ControllerPortValid(controllerPort)) { return 0; }
            return Input.GetAxis("Dpad_X-" + controllerPort.ToString());
        }

        /// <summary>
        /// returns float value "Project Setting> Input
        /// based on Dpad value
        /// Dpad_Y- + controllerPort
        /// </summary>
        /// <param name="controllerPort"></param>
        /// <returns>returns float depending on Dpad horizontal</returns>
        public static float DpadVertical(in int controllerPort = 1)
        {
            if (!ControllerPortValid(controllerPort)) { return 0; }
            return Input.GetAxis("Dpad_Y-" + controllerPort.ToString());
        }


        // Button Functions 

        /// <summary>
        /// returns bool "Project Setting > Input
        /// Action_0- + controllerPort
        /// Button.UP/DOWN/HOLD
        /// </summary>
        /// <param name="button"></param>
        /// <param name="controllerPort"></param>
        /// <returns>return bool value dependent on button press</returns>
        public static bool Action0(Button button, in int controllerPort = 1)
        {
            if (!ControllerPortValid(controllerPort)) { return false; }

            switch (button)
            {
                case Button.UP:
                    return Input.GetButtonUp("Action_0-" + controllerPort.ToString());
                //break;

                case Button.DOWN:
                    return Input.GetButtonDown("Action_0-" + controllerPort.ToString());
                //break;

                case Button.HOLD:
                    return Input.GetButton("Action_0-" + controllerPort.ToString());
                    //break;
            }

            return false;
        }

        /// <summary>
        /// returns bool "Project Setting > Input
        /// Action_1- + controllerPort
        /// Button.UP/DOWN/HOLD
        /// </summary>
        /// <param name="button"></param>
        /// <param name="controllerPort"></param>
        /// <returns>return bool value dependent on button press</returns>
        public static bool Action1(Button button, in int controllerPort = 1)
        {
            if (!ControllerPortValid(controllerPort)) { return false; }

            switch (button)
            {
                case Button.UP:
                    return Input.GetButtonUp("Action_1-" + controllerPort.ToString());
                //break;

                case Button.DOWN:
                    return Input.GetButtonDown("Action_1-" + controllerPort.ToString());
                //break;

                case Button.HOLD:
                    return Input.GetButton("Action_1-" + controllerPort.ToString());
                    //break;
            }

            return false;
        }

        /// <summary>
        /// returns bool "Project Setting > Input
        /// Action_2- + controllerPort
        /// Button.UP/DOWN/HOLD
        /// </summary>
        /// <param name="button"></param>
        /// <param name="controllerPort"></param>
        /// <returns>return bool value dependent on button press</returns>
        public static bool Action2(Button button, in int controllerPort = 1)
        {
            if (!ControllerPortValid(controllerPort)) { return false; }

            switch (button)
            {
                case Button.UP:
                    return Input.GetButtonUp("Action_2-" + controllerPort.ToString());
                //break;

                case Button.DOWN:
                    return Input.GetButtonDown("Action_2-" + controllerPort.ToString());
                //break;

                case Button.HOLD:
                    return Input.GetButton("Action_2-" + controllerPort.ToString());
                    //break;
            }

            return false;
        }

        /// <summary>
        /// returns bool "Project Setting > Input
        /// Action_3- + controllerPort
        /// Button.UP/DOWN/HOLD
        /// </summary>
        /// <param name="button"></param>
        /// <param name="controllerPort"></param>
        /// <returns>return bool value dependent on button press</returns>
        public static bool Action3(Button button, in int controllerPort = 1)
        {
            if (!ControllerPortValid(controllerPort)) { return false; }

            switch (button)
            {
                case Button.UP:
                    return Input.GetButtonUp("Action_3-" + controllerPort.ToString());
                //break;

                case Button.DOWN:
                    return Input.GetButtonDown("Action_3-" + controllerPort.ToString());
                //break;

                case Button.HOLD:
                    return Input.GetButton("Action_3-" + controllerPort.ToString());
                    //break;
            }

            return false;
        }

        /// <summary>
        /// returns bool "Project Setting > Input
        /// Action_4- + controllerPort
        /// Button.UP/DOWN/HOLD
        /// </summary>
        /// <param name="button"></param>
        /// <param name="controllerPort"></param>
        /// <returns>return bool value dependent on button press</returns>
        public static bool Action4(Button button, in int controllerPort = 1)
        {
            if (!ControllerPortValid(controllerPort)) { return false; }

            switch (button)
            {
                case Button.UP:
                    return Input.GetButtonUp("Action_4-" + controllerPort.ToString());
                //break;

                case Button.DOWN:
                    return Input.GetButtonDown("Action_4-" + controllerPort.ToString());
                //break;

                case Button.HOLD:
                    return Input.GetButton("Action_4-" + controllerPort.ToString());
                    //break;
            }

            return false;
        }

        /// <summary>
        /// returns bool "Project Setting > Input
        /// Action_5- + controllerPort
        /// Button.UP/DOWN/HOLD
        /// </summary>
        /// <param name="button"></param>
        /// <param name="controllerPort"></param>
        /// <returns>return bool value dependent on button press</returns>
        public static bool Action5(Button button, in int controllerPort = 1)
        {
            if (!ControllerPortValid(controllerPort)) { return false; }

            switch (button)
            {
                case Button.UP:
                    return Input.GetButtonUp("Action_5-" + controllerPort.ToString());
                //break;

                case Button.DOWN:
                    return Input.GetButtonDown("Action_5-" + controllerPort.ToString());
                //break;

                case Button.HOLD:
                    return Input.GetButton("Action_5-" + controllerPort.ToString());
                    //break;
            }

            return false;
        }

        /// <summary>
        /// returns bool "Project Setting > Input
        /// Action_6- + controllerPort
        /// Button.UP/DOWN/HOLD
        /// </summary>
        /// <param name="button"></param>
        /// <param name="controllerPort"></param>
        /// <returns>return bool value dependent on button press</returns>
        public static bool Action6(Button button, in int controllerPort = 1)
        {
            if (!ControllerPortValid(controllerPort)) { return false; }

            switch (button)
            {
                case Button.UP:
                    return Input.GetButtonUp("Action_6-" + controllerPort.ToString());
                //break;

                case Button.DOWN:
                    return Input.GetButtonDown("Action_6-" + controllerPort.ToString());
                //break;

                case Button.HOLD:
                    return Input.GetButton("Action_6-" + controllerPort.ToString());
                    //break;
            }

            return false;
        }

        /// <summary>
        /// returns bool "Project Setting > Input
        /// Action_7- + controllerPort
        /// Button.UP/DOWN/HOLD
        /// </summary>
        /// <param name="button"></param>
        /// <param name="controllerPort"></param>
        /// <returns>return bool value dependent on button press</returns>
        public static bool Action7(Button button, in int controllerPort = 1)
        {
            if (!ControllerPortValid(controllerPort)) { return false; }

            switch (button)
            {
                case Button.UP:
                    return Input.GetButtonUp("Action_7-" + controllerPort.ToString());
                //break;

                case Button.DOWN:
                    return Input.GetButtonDown("Action_7-" + controllerPort.ToString());
                //break;

                case Button.HOLD:
                    return Input.GetButton("Action_7-" + controllerPort.ToString());
                    //break;
            }

            return false;
        }

        /// <summary>
        /// returns bool "Project Setting > Input
        /// Action_8- + controllerPort
        /// Button.UP/DOWN/HOLD
        /// </summary>
        /// <param name="button"></param>
        /// <param name="controllerPort"></param>
        /// <returns>return bool value dependent on button press</returns>
        public static bool Action8(Button button, in int controllerPort = 1)
        {
            if (!ControllerPortValid(controllerPort)) { return false; }

            switch (button)
            {
                case Button.UP:
                    return Input.GetButtonUp("Action_8-" + controllerPort.ToString());
                //break;

                case Button.DOWN:
                    return Input.GetButtonDown("Action_8-" + controllerPort.ToString());
                //break;

                case Button.HOLD:
                    return Input.GetButton("Action_8-" + controllerPort.ToString());
                    //break;
            }

            return false;
        }

        /// <summary>
        /// returns bool "Project Setting > Input
        /// Action_9- + controllerPort
        /// Button.UP/DOWN/HOLD
        /// </summary>
        /// <param name="button"></param>
        /// <param name="controllerPort"></param>
        /// <returns>return bool value dependent on button press</returns>
        public static bool Action9(Button button, in int controllerPort = 1)
        {
            if (!ControllerPortValid(controllerPort)) { return false; }

            switch (button)
            {
                case Button.UP:
                    return Input.GetButtonUp("Action_9-" + controllerPort.ToString());
                //break;

                case Button.DOWN:
                    return Input.GetButtonDown("Action_9-" + controllerPort.ToString());
                //break;

                case Button.HOLD:
                    return Input.GetButton("Action_9-" + controllerPort.ToString());
                    //break;
            }

            return false;
        }

        /// <summary>
        /// returns boolean "Project Setting> Input
        /// based on trigger value
        /// LeftTrigger- + controllerPort
        /// </summary>
        /// <param name="controllerPort"></param>
        /// <returns>returns true if value on trigger is not 0</returns>
        public static bool LeftTrigger(in int controllerPort = 1)
        {
            if (!ControllerPortValid(controllerPort)) { return false; }

            if (Input.GetAxis("LeftTrigger-" + controllerPort.ToString()) != 0)
            {
                return true;
            }
            
            if(controllerPort == 1)
                return Input.GetKey(KeyCode.Mouse1);
            
            return false;
        }

        /// <summary>
        /// returns boolean "Project Setting> Input
        /// based on trigger value
        /// RightTrigger- + controllerPort
        /// </summary>
        /// <param name="controllerPort"></param>
        /// <returns>returns true if value on trigger is not 0</returns>
        public static bool RightTrigger(in int controllerPort = 1)
        {
            if (!ControllerPortValid(controllerPort)) { return false; }

            if (Input.GetAxis("RightTrigger-" + controllerPort.ToString()) != 0)
            {
                return true;
            }
            
            if(controllerPort == 1)
                return Input.GetKey(KeyCode.Mouse0);

            return false;
        }

        /// <summary>
        /// returns float "Project Setting> Input
        /// based on trigger value
        /// Triggers- + controllerPort
        /// </summary>
        /// <param name="controllerPort"></param>
        /// <returns>returns true if value on both triggers is not 0</returns>
        public static float Triggers(in int controllerPort = 1)
        {
            if (!ControllerPortValid(controllerPort)) { return 0; }

            return Input.GetAxis("Triggers-" + controllerPort.ToString());
        }
    }
}
