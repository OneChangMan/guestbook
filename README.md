# guestbook

A very simple guestbook consisting of a form and a grid showing guest comments.

The user can fill out the form to add a new comment or delete an already created comment.

What has been prepared but not yet implemented: editing of a comment, user location.


How to use the app:
Fill out the form. 
Only name and message contents are required. 
The user can but doesn't have to enter his/her email address.  Of course, the email address has to be valid.
Once the user submits his post/comment the comment will be shown in the grid on the right.
The user can then choose to update or delete the comment (or any other).

Not yet implemented:

Comment edit:
In commentsGrid_RowUpdating() I can't seem to get the newly updated data no matter what thus I'm not sure how to update the row.
My idea was to update the row and then add the time of the edit to the edited column of the comments table which contains user comments.

User location:
I've been wanting to create another table, continents, with continents, a simple two column table with ID and continentName.
This table, continents, would be related to the comments table's column continent.
The user would then be able to select a continent in a dropdown and the comments would show the selected continent.

What I wanted to do but didn't have enough time:
Rewrite the grid into a foreach cycle with neat, pretty posts. Of course, this would be including lazy load.
Add an admin user. This user would be the only one capable of editing and deleting comments.


How to run the project:
Git clone this repo into a folder.
Install Visual Studio and import this project that has been cloned into your folder.
Run Page.aspx.
