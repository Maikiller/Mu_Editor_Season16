config database

1° Adicione uma coluna em mu_online_login.accounts [type_account (int)] no seu usuário coloque o valor como [2] "Administrador"
2° Adicione uma coluna em mu_game.event_manager [guid (auto-increment)] na ultima linha
3° Adicione uma coluna em mu_game.shop_items [guid (auto-increment)] na ultima linha
4° mu_game.gate_template delete a 1° coluna com o [id] 0 e depois deixe o [id] como auto-incremento 