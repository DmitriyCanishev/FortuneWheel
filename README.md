# FortuneWheel
Fortune Wheel in Unity (Simple way to adding into your game)

## How Use
 - Create Page for FortuneWheel
 - Add component `SpinPageController` on it
 - Create child into that page with name **Wheel** that will be container for rewards sectors
 - Create sectors into **Wheel** gameObject with component `SpinSectorController`
 - Create SO : **Assets->Create->Configs-Spin->SectorsTypeSettings**
 - Fill it with some needed rewards (types (Into `RewardType` you can edit rewards on what you need)
 - Fill fields into SpinPageController object
 
 ## Helpers
 For optimizing time of creating FortuneWheel you can use `SpinSectorCreator`, in context menu exist method **CreateSectors**
 
 ## Major Notes
 1) Into SpinPageController exist variable **_isClockwiseDirection** which needed for change rotate direction (If you add sectors by counterclockwise direction, than uncheck this variable into `SpinPageController` inspector)
 
 2) Count of rewards and their values settings into `SpinDelegator` constructor
 