# Movies Web App

* For this project I created a Movie Class with the same properties as the created one on the Wep Api Project.
This class is located at the folder Models. I also created a class MoviesDate which is located in the MoviesData
Folder. In this class there are all the async Tasks that I am using to call the Api's that we created.


* The project also contains three pages .Our Index page where there is a list of all the movies .
What I did there is that i created a List of movies and i called the api for geting the movies from the DB.
Then foreach Movie found I display it.There is also the css file .I used the css Isolation that let us use css files 
for specific components and not globaly. Every movie title is clickable and it redirects the user to another page which
contains more details about the movie.


* From this page the user can see the movie description ,release date and director .There is also a button
there that allows the user to delete the movie .If the button get clicked the movie is delete and the user gets directed back 
to homepage.

* Finally there is ono more page that allows the user to add a new movie .The only field that is required is the Title.
If the user doesn't give any other values a placeholder image will be added and the release date and director 
will be shown  as UNKNOWN.The css of this page is on the top of the  page. 
 