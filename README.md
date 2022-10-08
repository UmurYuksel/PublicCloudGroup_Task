# PublicCloudGroup - Full Stack App Task

Important installation info and technical details for better user experience.

1) Project Installation:

  - **Important**: I didn't want to put the secret.json file into my repository for security reasons. Please put the **secret.json** into **publiccloudgroup_api/Constants folder**.  The Api will read it and set it to its environment. Also, since this is a public repository, I didn't want to use User-Secrets either.

2) Technical Details:

  This project was built in Visual Studio 2022 with .Net 6 Framework and React v18.
  Api uses Swagger for documentation, demonstration and test purposes.
  There are 3rd part libraries that I use in both React App and .Net Api.
    
    3rd part React libraries:  
      -Redux 
      -Redux-Thunk 
      -React-Notifications 
      -React-Router-Dom 
      -axios 
      -bootstrap
      -react-iframe
      
    3rd part .Net Libraries:
      -EntityFrameworkCore
      -SqlLite
      -JwtBearer
      -AutoMapper
      
 3) User-Story:
 
 You can find a simple User-Story that I created for this project below =>
 

Please see list of functions of the API I have been requested to develop: 

The API has the following functionalities;
  - Ability to fetch the information from Google Cloud Services about virtual machines via the API when fetch request is sent. 
  - Change Virtual Machine Statuses. Examples include ; Start, Stop, Suspend, Resume by sending Virtual Machine info to the API.

This allows for the following; 
  - Not having to manually get the virtual machine list from Google Cloud platfrom from the Compute Engine Dashboard. 
  - Not having to change machine statuses manually from the dashboard, eg; starting it, stopping it, suspending it, resuming it. 

Acceptance Criteria includes:
  - Ability to send a “get” request to the API to fetch virtual machines list.
  - Returning a list of the machines for the given project ID with specific detailing instead of all virtual machine details. 
  - Ability to send project-id, instance-name and zone to the API to request change of machine status. These fields are mandatory.
  - Return latest status of the machine and if the request was successful. 
  - If virtual machine is stopped, the ablility to send resume or suspend request to the API is disabled. 
  - Return a string message stating the operation cannot be achieved.

 Non-Functional Expectations include; 
  - Users authentication to use the API Functionality.
  - API to use DTO models to prevent unnecessary information sharing with the client.
  - API to have its own embedded database to verify users. 
  - API to have a documentation about requests and return types.
     
  
  



