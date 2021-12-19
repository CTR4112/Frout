# Frout
In order to function properly, the application needs a Google API key (as the solution works with google maps and resolves respective addresses)

Steps to make solution work:
1. create an Google Api key: (https://developers.google.com/maps/documentation/javascript/get-api-key))
2. input key at App.js at "const googleMapsApiKey = 'YOURKEYHERE'" (upper half of file) and save the file
3. run backend implementation using cmd with command "dotnet run" in frout_implementation folder
	(MySQL Server required, additionally login credentials of MySQL Server need to be maintained in "FroutDB" in file frout_backend/frout_implementation/appsettings.json)
4. run React implementation using cmd with command "npm run start" in frout_frontend folder
	(node.js and Node Package Manager required)