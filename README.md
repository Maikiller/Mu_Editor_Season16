# Mu_Editor_Season16
Mu Editor Season 16

Steps:

The server used and configured by SorinPy
https://github.com/SorinPy/Lgd-Server

I haven't tested other databases

Use the database:
https://github.com/SorinPy/Lgd-Server/blob/master/127_0_0_1.sql


To use Mu Editor it is necessary to make two modifications on the server.

1st mu_online_login
on the table
[accounts ] add column [type_account] as data type INT().

In your admin user put the value 2

2nd In mu_game in shop_items table
add column [guid] as data type INT() Auto Increment.

There are some that are just empty buttons.
However, they will be worked on in the future.

![alt text](https://i.ibb.co/8BWKWCL/Sem-t-tulo.png)

![alt text](https://i.ibb.co/znDrW6H/login.png)
![alt text](https://i.ibb.co/C5T62yt/main5.png)
