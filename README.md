DES2 FYP 2016-17
==================

Introduction
------------------
(VR Game Development using Unity and Leap Motion #1
Virtual reality (VR) games are computer games that allow players to immerse themselves in virtual environments and interact with the game elements via motion controller.
 With recent advances in game engine and motion sensing devices, like Unity and Leap Motion, developing high quality VR games is getting more popular. 
In this project, students are required to design and implement an interesting and fun-to-play networked VR game using Unity and Leap Motion. )

Requirements
------------------
Hardware:
- Google Cardboard or 
- Similar VR headmount using mobile as display
- Leap motion
- PC with Windows OS
- Android phone with USB Tethering

Software:
- Trinus VR app (available on Google Playstore)
- Leap Motion V2 Driver

Installation
------------------
1. Attach Leap Motion to VR Head-mount, with green signal light facing up
2. Connect Leap Motion & mobile to computer with USB cable
3. Disable mobile network data & Wi-fi
4. Go to Setting, enable USB Tethering
5. Launch Trinus VR app
6. Turn on Trinus and make sure bottom message shows "USB Detected"
7. Run fyp executive file on PC


Configuration
------------------
###Bullet types
To update bullet type, change <b>bulletPrefab</b> and <b>numOfBulletPerSecond</b> in ShootingManager

1. Bullet (numOfBulletPerSecond = 60)
2. BloodyKnife (numOfBulletPerSecond = 3)

###Change weapons

1. Define weapon's behaviors in <b>WeaponManager.cs</b>
2. Update WeaponType Enum in <b>WeaponManager.cs</b>
3. In every scene, <b>ShootingManager</b> must require a script component of <b>SceneWeaponsList.cs</b>
4. Edit weaponsList in <b>SceneWeaponsList</b> script component
5. Edit <b>Player.cs</b>, <b>SetWeaponBehv</b> function to include the new behavior
6. Play the game and try to change weapon(Wave hand with hand closed)!

###Add new scene

1. Add components: <b>ShootingManager</b>, <b>EnemyManager</b>, <b>GameManager</b>, <b>InfoPanel</b>, <b>SceneManager</b> and <b>Track</b> in the new scene
2. Decorate the scene, save the decoration as a prefab and put it into folder <b>Asset -> Prefab -> Decoration</b>
3. Import background music into folder <b>Asset -> Music</b>
4. Update music by draging it to the field <b>AudioClip</b> in <b>GameManager</b> component and edit attributes
5. Add <b>Photon Tranform View</b> and <b>Photon View</b> components to new enemy prefab
6. Drag the <b>Photon Tranform View</b> as the field <b>Observed Components</b> in <b>Photon View</b>
7. Check <b>Synchronize Position</b> inside <b>Photon Tranform View</b>
8. Change the Tag to <b>Enemy</b>
9. Put the enemy prefab into <b>Asset -> Resources</b>
10. For enemy using <b>ToonAnimations CTRL v1.0</b> as animation controller, uncheck <b>Apply Root Motion</b>; otherwise it will ignore Gravity
11. In <b>EnemyManager</b>, Drag enemy prefab from folder <b>Asset -> Resources</b> into the field <b>Enemies -> Element</b>
12. Update the boundary for spawning of enemy in <b>EnemyManager</b> if needed
13. Add the current scene into <b>Build Settings</b>
14. Add scene number into <b>ChangeScene.cs</b>

Troubleshooting
------------------
Q: Internet connection loss when USB Tethering turn on
A: With USB Tethering on, go Control Panel -> Network and Sharing Center -> Change adapter setting
   you should see two active connections, one is connected with Ethernet Controller which is the Internet connection and the other one is for USB tethering
   Right click the one for USB tethering, click Property. Select IPv4, click Properties, then click Advanced
   Uncheck Automatic metric and input 2000. Internet should resume.

Q: Trinus VR fail to connect to the game and shows port being used
A: First, try to kill Trinus VR app and re-launch it see if it works. If not, press the Option icon at bottom right, and set port number to something other than 7777,
   then go back to Trinus front page. In the Trinus connection page on PC, input the IP address shown on Trinus app front page and input the port number you set, then
   press Apply.     
   
Q: Leap motion is not working, no red light on front panel
A: Leap Service need to be active. Go to Task Manager, select Service, right click LeapService and Start service.
   
