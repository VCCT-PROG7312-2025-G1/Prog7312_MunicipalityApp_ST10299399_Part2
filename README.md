# PROG7312 - Municipality App
The repository is for a web application for a municipality. The application allows members of the community to submit reports about issues in their area to notify the municipality that it needs fixing. The application also allows the users to view local events that are happening and see the progress of the issue that they have submitted.

## Key Features
* **Report Issue:** User can submit detailed reports on diffrent issues like potholes and water leaks.
* **Upload Files:** Users can choose if they what to submit a file or image with their report.
* **View Issues:** Users are able to see all the issues that have been submitted already
* **Dynamic UI:** A modern home page that uses a carousel instead of just having 3 buttons
-- New Features
* **View Events:** Users are able to view events
* **Announcements:** Users are able to see announcements
* **Admin Login:** Admin is able to login and add new events to the system
* **Filter:** Users are able to filter events

## Advanced Data Stuctures used
* **Linked List:** Part 1 used in IssueCollection, IssueNode, IssueRepository
* **Sorted Dictionary:** Part 2 used in EventService for to keep and display events in order
* **Hash Set:** Part 2 used in Event Controller for filter feature
* **Queue:** Part 2 used in Event Controller for displaying events with title announcements
* **Hash Table:** Part 2 used in EventController for Recommendations Feature

## Technology Used
- Language: C#
- IDE: Visual Studio 2022
- Version Control: GitHub
- Framework: ASP.NET Core MVC .NET8

## How to run Project
1. Make sure to have Visual Studio 2022 installed on your PC
2. Clone the repository from Github
3. Open the solution file (.sln) in Visual Studio 2022
4. Build the solution: Navigate to Build in the menu and select Build Solution
   Build > Build Solution
5. Run the application

## Admin Login
Username: admin
Password: Admin@123

## Database Content
- Open SQLite and press open database
- Select the municipality.db file from the project folder

## Future Updates
- Status page improvements to make the page more modern

## References
- UI inspiration - https://swartland.org.za/
- Pro C# 10 with .NET6 Foundational Principles and Practices in Programming 11th Edition Andrew Troelsen and Phil Japikse
- C# Data Structures and Algorithms by Marcin Jamro
- Linked List: https://youtu.be/N6dOwBde7-M?si=GKx92yeDTyR7y1a7
- Carousel Implementation: https://stackoverflow.com/questions/60578096/mvc-c-sharp-carousel-image
                           https://youtu.be/XtFlpgaLbZ4?si=osT-hTxa4VJqUxtc
- Gemini: Help with hash set and sorted dictionary
- https://youtu.be/9y0DKw_H9zw?si=NsmaxeH7MdUdI0-O

