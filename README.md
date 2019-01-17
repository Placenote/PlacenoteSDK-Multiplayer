# PlacenoteSDK Multiplayer

A Unity project template to get you started creating a multiplayer augmented reality game using Placenote.

![Multiplayer_Gameplay](/Screenshots/Gameplay.png?raw=true "Multiplayer_Gameplay")

Placenote SDK: 1.6.11

Project's Unity Version: 2017.4.17f1

Xcode: 10.1

Photon PUN version: 1.92

Devices tested OS: 12.1

<br/>

### Getting Started

##### [Video Tutorial](https://youtu.be/n3a-aaSYR8s)

##### Download the unity package
* Download and install the
[Unity package](https://github.com/Placenote/PlacenoteSDK-Multiplayer/releases) into your own projects.
* Make sure you download and install the [PlacenoteSDK Unity package](https://github.com/Placenote/PlacenoteSDK-Unity/releases) as well.
* Open a new Unity project and import both of these packages.

#### OR

##### Clone this repository
* Critical library files are stored using lfs, which is the large file storage mechanism for git.
  * To Install these files, install lfs either using HomeBrew:

     ```Shell Session
     brew install git-lfs
     ```

      or MacPorts:
      ```Shell Session
      port install git-lfs
      ```

  * And then, to get the library files, run:
     ```Shell Session
     git lfs install
     git lfs pull
     ```
* Open the newly cloned project in Unity.

### Building the project
* Register for a Free Photon Multiplayer Account.
* Create a **Photon PUN app.**
* Place your "AppId" into the "PhotonServerSettings" in the editor.

<img width="1101" alt="photon appid" src="https://user-images.githubusercontent.com/13069075/38306822-9d5942ca-37c6-11e8-95ee-387d4eb2a614.png">

* Make sure you have a Placenote API key. [Get your API key here](https://developer.placenote.com)
* Load the sample scene `MultiplayerSampleScene` located in the `/PlacenoteMultiplayerKit/Scenes` folder
* To build and run the project on your iOS device, follow these [Build Instructions](https://placenote.com/docs/unity/build-instructions/)

<br/>
