
# Hostel Management System

This project aims to simplify the tedious process of hostel booking and allotment by digitalizing the process hereby making it easier for students to book and view allotment or apply for changes and for the administration to keep track of students residing in various hostel blocks.


## Features

- Multiple user privileage logins
- GUI based user-friendly experience
- Validation checks for data consistency
- Windows-exclusive executable application
- Extensive backend


## License

[GNU General Public License v3.0](https://choosealicense.com/licenses/gpl-3.0/)


## Feedback

If you have any feedback or suggestion, please reach out at sjrj0604@gmail.com


## Appendix

Any additional information goes here


## Design and Implementation

After the database design and implementation, we designed and implemented the frontend of the Hostel Management System using VC#. This includes designing the user interface, creating forms and screens, and integrating the frontend with the backend database using SQL connectivity. Our goal during this phase is to create a user-friendly interface allowing users to easily interact with the system. Using disappearing labels for format validation and message boxes, we have made sure that our application operates crash-free. The users are initially met with the login page from which they can migrate to register if not already a user, change password if needed or login to respective roles based on their registration numbers. The nomenclature for registration numbers are as follows: 
- **Student**: Starts with the digit 2 and consists of a total of 8 digits.
- **Caretaker**: Starts with the digit 1 and consists of a total of 3 digits.
- **Administrator**: Starts with the digit 0 and consists of a total of 5 digits.

After logging in successfully, the users are redirected to their respective landing pages. The student initially is able to view the information set during registration and is supposed to edit cgpa, branch and gender before proceeding to room booking. Initially the mess change and room change features are blocked unless the room is booked. After successful room booking, the profile page is updated and the students are not enabled to change mess and hostel rooms. 

Messes are predetermined based on the hostel blocks selected initially can be changed after applying for a mess change. The students are also provided with a feature to lodge a complaint or ask a query to the caretakers through this system. Also at all times, the student inbox feature is enabled where any approved or rejected applications are visible. The students can also log out of the system at all times using the logout button.

For the administrators, they are enabled with approval features of any student applications for hostel room change or mess change. The listboxes provided are pre-filled with the requests and have the option to either approve or reject their proposals. They also have a feature to view caretaker details and filter results specifically based on blocks or using a Caretaker ID.

The caretakers have control over any issues or student queries. The listboxes provided are pre-filled with the requests and once resolved, are sent to students for confirmation. They also have a feature to view student details and filter results specifically based on blocks or using student registration numbers.


