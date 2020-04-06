# TE-Gram Project

Our entire IT Team had the good fortune of hitting on a huge group PowerBall lottery ticket.  Unfortunately for us they have all resigned.

They were in the middle of a very important project that has a deadline of Friday night and now we have no one to complete it.

You have been engaged to complete the unfinished portions of the the project by the deadline.

## Project Overview

TE-Gram is a photo-sharing app that will allow users to upload photos that can be viewed by anyone with access to the TE-Gram site.

Users can browse photos, indicate which ones they like, bookmark their favorites, display all photos from a particular contributer, view all their favorites and upload new photos.

## Current status:

* Items that are know to exist in some form:
  - A repository and directory structure to hold project assets.
  - Several tables and associated DAOs  
  - Wireframes for web pages showing expected layout and content
  - A home/landing page
  - Coding of some features
  
* Requirements still to be implemented:
  - As a user, I would like to be able to add new comments to an existing photo.
  - As a user. I would like to tap/click on a contributor name and see a list of photos submitted by the contributor.
  -  As a user, I would like to tap/click an indictor to show I like a particular photo.
  -  As a user, I would like to bookmark a photo as a favorite.
  -  As a user, I would like to be able to list all my favorites by user.
  -  As a user, I would like to be able to add new photos.

## Collaborating in a shared repository

Each team will be working in the same shared repository.  In order to collaborate in this manner, each team member will need to:

1. Clone the shared repository.
2. Create a branch for their work - Use the names of the team members of the branch name (eg. JoshCraigFrankMike)
   - ```cd to cloned repository directory```
   - ```git branch new-branch-name```  
3. Checkout the branch for their work.
   - ```git checkout new-branch-name```
   
   Note: the ```git branch``` command can be used to see which branches you have checked out locally.  The current working branch will be shown with an '*' next to it's name.
4. Perform all their work in their branch.
5. When ready to save changes to Bitbucket branch:
   - ```git add -A```
   - ```git commit -m'commit message'```
   - ```git push origin new-branch-name```
         
6. To get your change reviewed and merged in to the master branch:
   - Go to the repository in Bitbucket
   - Click the plus sign on the left side and choose ```Create a pull request```   You can see your branch as the source branch and master in the destination branch. 
   - Be sure to provide a meaningful description in the Pull Request
   - Select at least 2 other team members (along with the instructors) as reviewers.




   
