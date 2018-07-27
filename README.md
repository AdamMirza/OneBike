# MS One Bike

The greatest project at Microsoft OneWeek 2018. A ride share program for bicycles on Microsoft's Redmond campus.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

You'll need to get the latest version of Angular, Angular CLI, and NPM installed on your machine.

See: https://cli.angular.io/

### Project Structure
**Backend**
The backend handles the API to communicate with the servers. See the YAML file for the API definition.

**Frontend**
There are multiple folders for frontend. The `frontendFIN` folder is the completed design for the site, but `Frontend-angular` is the implementation for the app.

`Frontend-angular` is the onboarding and login process (login is mocked up). This folder has all source code in `src` to make the website happen. The *register* process occurs in `register`, *login* in `home`, and the *app* will be hosted in `app-home`.

### Running

After getting your machine set up, you will be able to deploy the frontend server using the following commands.

First cd into the `frontend-angular` folder, then run the serve command:

```
ng serve
```
The server will run on localhost port 4200.

### Emails that work
Only emails with `@microsoft.com` endings will work on the angular frontend login. The two emails that are hardcoded to be users are:
* hello@microsoft.com
* satyan@microsoft.com
