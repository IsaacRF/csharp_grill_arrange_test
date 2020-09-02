# GRILL ARRANGE TEST APP
- **Author:** Isaac R.F. (isaacrf239@gmail.com)
- **Test owner company:** isolutions
- **Language:** C#, .Net
- **Test Specifications:** [Link](https://github.com/IsaacRF/csharp_grill_arrange_test/blob/master/SPECIFICATIONS.pdf)

## Description
Grill arrange console app that retrieves different menus from a REST API and calculates and optimizes the cooking order, sorting and required rounds to cook all items in every menu.

![grill_demo](https://user-images.githubusercontent.com/2803925/92026635-97a4ec00-ed61-11ea-9fa2-b072bb6f474e.gif)

## Project parts
1. Executable is located on bin/Release/Grill Arrange Test.exe.
2. Unit tests are located under UnitTesting project.

## Execution
1. Execute app exe and enter a valid grid length and width
2. App automatically retrieves menus, sorts them, and shows info of every round required for every menu
3. Press Enter again to close app

## Known Bugs
- [ ] Infinite loop when specified grill size is too small
