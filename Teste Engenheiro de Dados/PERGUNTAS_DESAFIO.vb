Data Engineering Test
Attention

Fork this repository in order to start building your solution. Then when you're done, send us a link to your repository with the solution.
Requirements

    Docker version >= 19.03
    Docker-compose version >= 1.25

Fire up your PostgreSQL instance by opening a terminal and running the following command:

docker-compose up -d 

Using your prefered DB Client (DBeaver for instace).

You have a folder (raw_data) that contains:

    JSON data from real estate ads,
    a CSV file with buildings.

Its required that you write a script to identify for each ad, which building it belongs to. After successfully identifying that an ad X belongs to building Y, load the enriched ad data into a PostgreSQL table (or set of tables). You should also provide the sql statements to create the table(s) into PostgreSQL database.
Tips and things to keep in mind

    Organize your workflow in a way that you also provide instructions on how to run your scripts.
    Is your solution able to find a building for every ad? Don t worry if it's 100%, but can you explain why?
    What would you do differently if you had more time?
    Feel free to use any language you're comfortable with, but keep in mind that organization and comments are welcome to explain your train of thought.
