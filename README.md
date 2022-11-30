# ECSteroids

2D клон оригинальной игры Asteroids.

### Управление

<kbd>W</kbd> / <kbd>ArrowUp</kbd> - Ускорение

<kbd>A</kbd> <kbd>D</kbd> / <kbd>ArrrowLeft</kbd> <kbd>ArrowRight</kbd> - Поворот

<kbd>Q</kbd> - Смена оружия

<kbd>Space</kbd> - Стрельба

### Задание

Необходимо разработать 2D клон оригинальной игры Asteroids.

Цель игры – получить как можно больше очков, расстреливая астероиды и летающие тарелки, избегая при этом столкновения с ними.

Игрок управляет космическим кораблём, который может крутиться влево и вправо, двигаться только вперед и стрелять. Движение корабля должно быть с ускорением и инерцией. Экран не ограничивает передвижения, а является порталом, т.е. если вы упираетесь в верхнюю границу, то появитесь с нижней.

У корабля есть два вида оружия:
пули при попадании в астероид разбивают его на обломки меньшего размера, обладающие большей скоростью; попадание пуль в обломки или летающую тарелку приводит к их уничтожению;
лазер уничтожает все объекты, которые пересекает. Игрок имеет ограниченное количество выстрелов лазером. Выстрелы пополняются со временем.

При столкновении космического корабля с астероидом, обломком или летающей тарелкой выводится сообщение о проигрыше со счетом и приглашением начать игру заново.

После старта игры периодически появляются астероиды и летающие тарелки. Астероиды двигаются в случайном направлении, а летающие тарелки преследуют игрока. Астероиды и летающие тарелки между собой не сталкиваются.

Необходимо добавить UI, на котором будут отображаться показатели корабля:
координаты
угол поворота
мгновенная скорость
число зарядов лазера
время отката лазера

Требования к реализации: 

язык программирования: C# 
логику игры необходимо сделать независимой от визуального представления.

