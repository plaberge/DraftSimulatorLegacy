###(Please note that this ReadMe file is not yet complete.  The intent is to provide you with all the instructions necessary to configure and deploy the DraftSimulator to your own Azure subscription, so please be patient!)

# DraftSimulator
This is the repo for the DraftSimulator demo described at https://channel9.msdn.com/Blogs/Breakpoint/An-End-to-End-Demo-of-VSTS and https://www.youtube.com/watch?v=07-G0GPWA0M.

## What is the DraftSimulator?
The DraftSimulator is a sports league draft simulator.  If you are familiar with professional sports leagues, you might know that every year the league will hold a draft to determine which new, young talent will play for each team in the league the following year.  Some leagues have implemented an algorithm to determine which team gets the first pick of the draft and that is what this demo web application does.  Basically, it runs a draft simulation to determine which team gets the first pick of the draft for a fictitious league.

### Is there an example of this demo I can try out?
Sure, just head over to https://draftsimulator.azurewebsites.net and try it out!

## Pull Requests
You are more than welcome to take this code and use it how you see fit per the MIT license rights.  If you want to contribute to this project and create a pull request with your great additions and fixes, go for it!  I can't promise to be immediate in my review of the pull request as I have a day job, but I will try to get to it when I can.

## Installing the DraftSimulator
There are a few things required to run the DraftSimulator as-is.  The application is meant to be hosted on the Microsoft Azure Web App service, but it can be run locally in debug mode or on an IIS server.  The following things are required to make the solution work the way I run it in my demo (listing is per environment; if you have multiple environments you may want to have these services in each of those environments):
- An App Service Plan on the Standard Tier (or, alternatively, an App Service Environment/ASE for even more horsepower)
- An Azure Web App (deployment slots can be used for hosting each Web App environmental instance, but the App Service Plan hosting the web app must be at least Standard Tier to support deployment slots)
- A SQL Server Database (my instance is running on an Azure PaaS SQL Database, Basic Tier)
- An Azure Application Insights tenant for application telemetry
- Azure BLOB storage for the team logo images (I have my read access to BLOB storage as anonymous so that the images are publicly accessible; I saw no need to require authentication for accessing the team logo images)
- An Azure Function to gather the daily standings from a third party (you don't need to include this in your application instance; if you are getting league standings data on a regular basis, then this is helpful, otherwise you can do without this)

# Open Issues
None known at this point.
