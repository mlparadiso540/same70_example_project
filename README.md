# same70_example_project

This repository contains two projects: <br/>
SAME70_EXAMPLE: <br/>
This is the code that runs on the Atmel SAME70 Xplained board. It was created in Atmel Studio and is written in C <br/>
SAME70_CLIENT: <br/>
This is a GUI used to monitor and control the state of IO's on the SAME70 Xplained board. It was created in Microsoft Visual Studio and is written in C# using the Windows Presentation Foundation (WPF) framework.<br/><br/>
__What you will need:__
* PC<br/>
* Atmel Studio<br/>
* Microsoft Visual Studio<br/>
* Atmel SAME70 XPLAINED board<br/>
* ethernet cable<br/>
* Atmel programmer (may or may not need, see "Getting Started" step 3)<br/>
<!-- end of list --><br/>
__Getting Started:__
* Download the code in this repository, then open and build each project in it's respective IDE <br/>
* Connect SAME70 XPLAINED board to your PC via USB. There are two USB ports on the SAME70 XPLAINED board, connect the one labelled "DEBUG USB" <br/>
* In Atmel Studio, push the code to SAME70 XPLAINED board by pushing the green "play" button at the top of the screen. If you are prompted to select a programming tool, select EDBG (Embedded Debugger). <br/>
note: Atmel Studio and/or Atmel drivers do not always work correctly. If EDBG is not available, you may need to purchase an external Atmel programmer. The programmer used for this project was the Atmel SAM-ICE J-Link by Segger (www.segger.com) <br/>
* Connect the SAME70 XPLAINED board to your PC with the ethernet cable <br/>
* Run the SAME70_CLIENT<br/>
<!-- end of list --><br/>
__Controlling the SAME70 XPLAINED:__<br/>
This project configures the SAME70 XPLAINED to have 8 outputs and 8 inputs<br/>
IO D0-D7 are configured as outputs, shown below<br/>
![image outputs](https://github.com/mlparadiso540/same70_example_project/blob/master/images/SAME70_OUTPUT.png?raw=true)<br/><br/>
IO D14-D19 and D52-D53 are configured as inputs, shown below<br/>
![image inputs](https://github.com/mlparadiso540/same70_example_project/blob/master/images/SAME70_INPUT.png?raw=true)<br/><br/>
D14-D17 are configured as pull-downs. They are grounded in their normal state and trigger when power is applied<br/>
D18-D19 and D52-D53 are configured as pull-ups. They are 3.3v in their normal state and trigger when ground is applied <br/><br/>
When the SAME70 CLIENT is run, the following screen is displayed<br/>
![image client](https://github.com/mlparadiso540/same70_example_project/blob/master/images/SAME70_CLIENT.png?raw=true)<br/><br/>
Clicking a Toggle button will switch the respective IO on/off. The circle indicator above each button will turn green when the respective IO is outputting 3.3v, and will turn gray when outputting 0v. The circle indicator under each input will turn green when the respective input is triggered. For D14-D17 (pull-down inputs), they will turn green when 3.3v is applied. For D18-D19 and D52-D53 (pull-up inputs), they will turn green when ground is applied. <br/>
In the screenshot below:<br/>
-D0 is outputting 3.3v<br/>
-D14 has 3.3v applied<br/>
-D53 is grounded<br/>
-All other IO's are in their normal state<br/>
<!-- end of list --><br/>
![image on](https://github.com/mlparadiso540/same70_example_project/blob/master/images/SAME70_CLIENT_ON.png?raw=true)<br/><br/>
__Troubleshooting__<br/>
Problem: The SAME70 CLIENT is not communicating with the SAME70 XPLAINED<br/>
Solution: Trying pinging the SAME70 XPLAINED. Open the command prompt and type "ping 192.168.0.100". If there is no response, you will need to configure your ethernet port
* Click the Windows start menu and type "Ethernet" and open Ethernet Settings<br/>
* Click "Change Adapter Options" <br/>
* Right-click the ethernet port that the SAME70 XPLAINED is connected to, then select "Properties" <br/>
* Select "Internet Protocol Version 4 (TCP/IPv4)" in the menu, then click the Properties button <br/>
* Select "Use the following IP address" and enter the following:<br/>
  * IP Address: 192.168.0.99<br/>
  * Subnet Mask: 255.255.255.0<br/>
  * Default Gateway: 192.168.0.1<br/><!-- end of list -->
* Click the OK button to apply changes <br/>
* You should now be able to successfully ping the device. You may need to restart the command prompt <br/>
<!-- end of list --><br/>
Problem: I can ping the SAME70 XPLAINED and can see network traffic on Wireshark, but SAME70 CLIENT is still not communicating<br/>
Solution: Your firewall is probably blocking the SAME70 CLIENT. You will need to allow it
* Click the Windows start menu and type "firewall", and open Windows Defender Firewall with Advanced Security <br/>
* Select Inbound Rules in the left pane <br/>
* Find "same70_client.exe" in the list, there will be 4 rules. Double-click each one, make sure "Allow the connection" is selected, and click Apply <br/>
* The SAME70 CLIENT and SAME70 XPLAINED should now be communicating. You may need to reset the client <br/>
<!-- end of list -->












