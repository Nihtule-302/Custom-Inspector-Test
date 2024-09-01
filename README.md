# Custom Tools

## Object Spawner

(Tools Images/Object Spawner/Object%20Spawner%20Tool.jpg)
![Object Spawner Demonstration](Tools Images/Object Spawner/Object%20Spawner%20Demonstration.jpg)

The **Object Spawner** tool is a custom Unity Editor window designed to facilitate the spawning of objects within a specified area. Here’s a quick overview of its features and functionalities:

### Features

- **Prefab Selection:** Choose any GameObject prefab to instantiate.
- **Object Count:** Specify the number of objects you want to spawn.
- **Spawn Radius:** Define the radius of a sphere within which the objects will be randomly placed.
- **Color Variations:** Add and manage a variety of colors. The objects will be assigned random colors from this list upon instantiation.
- **Object Placement:** Objects are spawned on the surface of a sphere defined by the `Spawn Radius`.

### Usage

1. **Open the Tool:**
    - Navigate to `Tools` > `Object Spawner` in the Unity Editor menu.

2. **Configure Settings:**
    - **Prefab:** Drag and drop the prefab you want to spawn.
    - **Number of Objects:** Enter the number of objects you wish to instantiate.
    - **Spawn Radius:** Use the slider to set the radius of the spawning area.

3. **Manage Colors:**
    - **Add New Color:** Specify a color and click "Add Color" to include it in the list.
    - **Color List:** View and manage the list of colors. You can also remove colors from the list.

4. **Instantiate Objects:**
    - Click the "Instantiate Objects" button to spawn the objects with the configured settings.

### Example

Here's how you might use the Object Spawner tool:

1. **Select a Prefab:** Choose a prefab from your project.
2. **Set Parameters:** Define the number of objects, set the spawn radius, and add any desired colors.
3. **Spawn Objects:** Click "Instantiate Objects" to see your prefab objects appear randomly within the defined sphere, each with a random color from your list.

### Important Notes

- Ensure your prefab has a `MeshRenderer` component if you want it to display the random colors.
- The tool will only function properly if a valid prefab is assigned.
