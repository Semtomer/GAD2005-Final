# GAD2005-Final
This repository is the final project of the GAD2005 Game Development Practices course I took in the Digital Game Design department at Bahcesehir University. (3rd grade 2nd semester)

Note: When you open the project with the unity editor, first open the scene named "MainMenu" and then set the Resolution to 1920x1280.

The details of the given project assignment are as follows:                         

Final Project                  
In the scope of this, you will create an idle game. The game will consist of two main visual sections: Map and Menu. 
In the map section, the player will see a 10x10 grid. In the menu section, there will be a resources panel and a building panel. 
In the resources panel, the player will see two resources: Gold and Gem. In the building panel, there will be 6 buildings. 
Each building will be displayed in the form of a card. For each building; their name, cost, and image will be displayed on them. 
Buildings in the building panel will be either enabled or disabled, depending on whether their cost can be paid or not.

The player will be able to drag a building from the building panel and drag over the tiles on the map. 
As long as the player is dragging a building, the shape of the building will appear on the map and will follow the player’s mouse. 
The building’s shape will appear as green and semi-transparent on the tiles where the player can construct the building on. 
The shape of the building will appear red and semi-transparent on tiles which can not be built on. 
If the player drops the building on already occupied tiles or outside of the grid, then construction will be canceled.

When the player constructs a building, the cost of the building will be reduced from the player’s resources. 
This will be indicated by floating texts over the newly constructed building and the over the resources panel.

Each building can generate gold and/or gem. 
After X seconds, the building will generate Y gold and Z gem (X, Y, and Z will be configurable and will be stored per building type). 
In the map section, each building on the grid will have a progress bar on them. 
Each of these progress bars will show a number counting down and a fill bar. 
Generated resources will be shown as floating text over the building and the player’s resources panel.

Each building’s name, image, cost, resource generation duration, generated resources, and shape of the building will be configurable.
A designer in the team should be able to configure the values with ease and be able to create new types of buildings. 

When a player stops playing, their game state will be persisted.
When the player starts playing the game again, they will see the previous state of their game.
The map will have the previously constructed buildings, and the resources will be the same as the last time the play session ended.
In the menu section, there is a restart button. When the player clicks on it, the game state will be reset.

In the beginning, the player will start with 10 gold and 10 gems.

Here is the wireframe:
![image](https://github.com/Semtomer/GAD2005-Final/assets/77025357/f116e903-fe41-44a2-9f94-f74bce98a3e6)
