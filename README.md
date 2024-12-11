# Weather and To-Do List Application

This project integrates a Weather app and a To-Do List application into a single user-friendly platform. Both components are built using the MVVM architecture to ensure clean code, separation of concerns, and maintainability.

## Features

### Weather Application
- **Current Weather**: Displays the current weather based on the user's location.
- **Search by City**: Allows users to search for weather information by city name.
- **Weather Details**: Provides temperature, humidity, and weather conditions.

### To-Do List Application
- **Add Tasks**: Create new tasks with unique titles.
- **Mark as Completed**: Mark tasks as completed using a checkbox.
- **Persistent Storage**: Tasks and their states persist even after the app is closed.
- **Edit Tasks**: Update the title of existing tasks.
- **Delete Tasks**: Remove tasks from the list.
- **Incomplete Task Count**: View the count of incomplete tasks in real time.

## Architecture

This application is built using the **Model-View-ViewModel (MVVM)** design pattern:

- **Model**: Represents the data and logic (e.g., `ToDoItem`, `WeatherData`, `IToDoService`, `IWeatherService`).
- **View**: The user interface (e.g., XAML files for To-Do List and Weather pages).
- **ViewModel**: Acts as the binding layer between Model and View (e.g., `ToDoTaskPageViewModel`, `WeatherPageViewModel`).

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/your-repo/weather-todo-app.git
   ```
2. Open the project (e.g., Visual Studio or Rider).
3. Build and run the application.

## How to Use

### Weather Application
1. Navigate to the Weather page.
2. View the current weather based on your location.
3. Search for weather details by entering a city name.

### To-Do List Application
#### Adding a Task
1. Navigate to the To-Do page.
2. Enter a task title in the input field.
3. Click the "Add" button to add the task to the list.

#### Editing a Task
1. Long press or use the edit option (if available) on a task.
2. Enter the new title and save the changes.

#### Deleting a Task
- Use the delete button next to a task to remove it from the list.

## Code Overview

### Key Files

#### To-Do List
- **`ToDoItem`**: Represents a single to-do item with properties `Id`, `Title`, and `IsCompleted`.
- **`IToDoService`**: Interface for handling to-do data storage and operations.
- **`ToDoService`**: Implements `IToDoService`, using local preferences for persistent storage.
- **`ToDoTaskPageViewModel`**: The ViewModel handling all task-related logic and UI binding.
- **`ToDoTaskPage.xaml`**: The XAML view displaying the task list and controls.

#### Weather Application
- **`WeatherData`**: Represents weather details fetched from the API.
- **`IWeatherService`**: Interface for weather-related data fetching.
- **`WeatherService`**: Implements `IWeatherService`, interacting with a weather API.
- **`WeatherPageViewModel`**: The ViewModel handling weather data fetching and UI binding.
- **`WeatherPage.xaml`**: The XAML view displaying weather information.

### Key Methods
#### To-Do List ViewModel
- `LoadToDoItemAsync`: Loads all tasks from storage.
- `AddToDoItemAsync`: Adds a new task to the list and saves it.
- `ToggleToDoItemCompletionAsync`: Toggles the completion status of a task.
- `EditToDoItemTitleAsync`: Updates the title of an existing task.
- `DeleteToDoItemAsync`: Removes a task from the list.

#### Weather ViewModel
- `LoadWeatherAsync`: Fetches weather details based on the user's location or a provided city name.
