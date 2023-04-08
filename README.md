# LabStreamingLayer(LSL)-enabled Onscreen keyboard typeing test program built in Unity #

This is a simple touch screen typing test program in Unity. The program has LSL embedded which can be picked up with Lab Recorder or other LSL compatible programs for precise events and timestamps. Currently the program is hard coded for a screen resolution of 1920x1280 but the keyboard can be easily modified by replacing the keyboard image in "Typing" scene and resizing/modifying colliders of each key. 

The program names the data files with "ParticipantID_Session_Timer_Paragraph" info and outputs three files that can be found in C:\Users\<your profile name>\AppData\LocalLow\Cozywolf\
1. data: Records the on-hit time and coordiante for each key (plus the center of each key). e.g., "Hit, 2023-04-08 01:09:29.919,Target:,r,Target Position:, (592.64, 487.68, 8.50),Touch Position:, (580.55, 483.27, 0.00)"
2. keyinfo: Records the boundaries (four corners) of each key. e.g., "q,(84.74, 551.68),(217.86, 551.68),(217.86, 423.68),(84.74, 423.68)"
3. result: Records what has been entered.

To be added:
1. Responsive design for different screen sizes
2. Additional keyboard layouts and a function to import keyboard keyouts
3. An actually character/word matching checker to display and calculate Word-per-Minute (WPM), and Adjusted-Word-per-Minute (AWPM)