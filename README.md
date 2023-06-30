# Geolocation Detection in ASP .NET CORE MVC

Welcome to my GitHub project! 
In this repository, you will find a code snippet that is part of a larger project. The main objective of this code is to detect the country of the website visitors as they browse through the respective sites.

The project utilizes the ipinfo API, which provides valuable information about the visitor's IP address. By leveraging this API, we can extract the country details of the visitors in real-time. If you want to learn more about the ipinfo API, feel free to visit their website at https://ipinfo.io/.

Please note that this code snippet is just a portion of the complete project. However, it serves as a fundamental building block for implementing country detection functionality in web applications.

I hope you find this project informative and useful. Feel free to explore the code and provide any feedback or suggestions. Thank you for visiting this repository, and don't hesitate to reach out if you have any questions or need further assistance.


## Branch "debugged_return_of_same_ipaddress"

This branch is created when i test the project in deployment server, where I encounter error of getting same ip address over and over again (the ip is my deployment server instead of client's server), I have not identified the exact cause and error yet, but this branch code is using another way of retrieving client's IP address, through "IHttpContextAccessor". 
