﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDinner
{
}

//Cheese dinners

public class MacAndCheese : IDinner { }
public class Pizza : IDinner { }
public class Cheeseburger : IDinner { }
public class Souffle : IDinner { }

//Vegan dinners

public class Tofu : IDinner { }
public class Bruschetta : IDinner { }
public class VeggieStew : IDinner { }
public class Ratatouille : IDinner { }