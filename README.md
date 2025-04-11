# Coding Tracker Application

## Overview

The **Coding Tracker Application** allows users to track their coding sessions over time. Users can either:

- Manually input the start and end times of their sessions.
- Track sessions in real-time by starting and ending the session directly through the application.

Additionally, users can:

- View a list of their recorded coding sessions.
- Generate summarized reports of their sessions, grouped by week, month, or year.
- Order the session results either in ascending or descending order.

## Features

- **Add Session Manually**: Input the start and end time of your coding session manually.
- **Track Session in Real-Time**: Start and stop your coding session in real-time with the "Start Session" and "End Session" options.
- **View Sessions**: View a list of your recorded coding sessions, including start times, end times, and duration.
- **Generate Reports**: View your sessions summarized by week, month, or year. You can also order the results in ascending or descending order.
- **Database Storage**: Data is stored in an SQL Server database that is managed through a Docker container.

## Setup Instructions

To get the Coding Tracker Application up and running, follow these steps:

### Prerequisites

- **Docker** must be installed on your system.
    - Install Docker from [here](https://www.docker.com/get-started).

### Steps to Run

1. Clone this repository to your local machine.
2. Open the project folder in your terminal or command prompt.
3. Run the following command to set up and start the SQL Server database container:

    ```bash
    docker-compose up --build
    ```

   This will build the Docker image (if not already built) and start the container for the SQL Server database where the session data will be stored.

4. After the container is up and running, you can interact with the application using the available commands in the menu.

## Usage

### Add Session Manually

- Use the **Add Session** option from the menu to input a session's start and end times manually.

### Track Session in Real-Time

- Use the **Start Session** button to begin tracking your session.
- Click **End Session** (or quit the app from menu) when you're done, and the session details will be automatically recorded.

### View Sessions

- Navigate to the **View Sessions** section to see a list of all your recorded sessions, including start times, end times, and total duration.

### View Reports

- You can generate reports to summarize your sessions based on:
    - **Weekly**: Grouped by week.
    - **Monthly**: Grouped by month.
    - **Yearly**: Grouped by year.
- You can order the results either in **ascending** or **descending** order based on the specified criteria.

### Example Report

If you choose to view a **monthly report** ordered **descending**, the application will show the months with the most coding time first.

## Contributing

Feel free to fork the repository and submit pull requests. Any contributions are welcome!

### Reporting Bugs

If you find any bugs or have feature requests, please open an issue in the GitHub repository.

## Contact

If you have any questions or suggestions, feel free to open an issue or contact the project maintainers.

---

Thank you for using the **Coding Tracker Application**!
