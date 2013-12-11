function Magazine()
{
	this.capacity = 0;//maximum number of bullets
	this.calliber = "";
	this.popTime = 0;//time between 2 pops of cartridges in ms
	this.assemblyTime = 0;//time to create a magazine
	this.loadTime = 0;//time to load a magazine into a weapon in ms
	this.refillTime = 0;//time to refill a magazine in ms
	this.neededMetal = 0;//needed metal for assembly in objects
	this.neededGunpowder = 0;//needed gunpowder for assembly in objects
	this.quality = 0;//lower quality increases popTime, loadTime and refillTime

	this.cartridges = [];
	this.reduceQuality = function reduceQuality()
	{

	}
	this.getRefillTime = function getRefillTime()
	{

	}
	this.getPopTime = function getPopTime()
	{

	}
	this.getLoadTime = function getLoadTime()
	{

	}
	this.pushCartridge = function pushCartridge(cartridge)
	{
		if (pushable(cartridge))
		{
			this.cartridges.push(cartridge);
		}
	}
	this.popCartridge = function popCartridge()
	{
		if (popable())
		{
			return this.cartridges.pop();
		}
	}
	this.popable = function popable()
	{
		if (empty())
		{
			return false;
		}
		return true;
	}
	this.pushable = function pushable(cartridge)
	{
		if (full())
		{
			return false;
		}
		if (this.calliber != cartridge.calliber)
		{
			return false;
		}
		return true;
	}
	this.empty = function empty()
	{
		return this.cartridges.length == 0;
	}
	this.full = function full()
	{
		return this.cartridges.length == this.capacity;
	}
}

function Cartridge()
{
	this.accuracy = 0;
	this.calliber = "";
	this.speed = 0;//speed in meter per second
	this.damage = 0;//damage dealt to target on hit
	this.explosionRadius = 0;//all targets in range get damage, hit target twice (1 from being hit, 1 from explosion)
	this.freezeTime = 0;
	this.slowTime = 0;
	this.burnTime = 0;
	this.quality = 0;
}

function Metal()
{
	this.stock = 0;
	this.quality = 0;
}

function Gunpowder()
{
	this.stock = 0;
	this.quality = 0;
}

function Player()
{
	this.gunpowder = 0;
	this.metal = 0;
}
