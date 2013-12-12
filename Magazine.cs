using System;
using System.Collections.Generic;

public class Magazine : Product
{
	public int capacity;
	private int popTime;
	private int loadTime;
	private int refillTime;
	private Stack<Cartridge> cartridges;
	public Magazine()
	{
		capacity = 0;//maximum number of cartridges
		popTime = 0;//time a cartridge needs to pop in ms
		assemblyTime = 0;//time needed to assemble in ms
		loadTime = 0;//time to load magazine in weapon in ms
		refillTime = 0;//time to refill 1 cartridge in ms
		material;//material the magazine is made from
		cartridges = new Stack<Cartridge>();
	}
	public int getPopTime()
	{
		return (100.0/getQuality())*popTime;
	}
	public int getLoadTime()
	{
		return (100.0/getQuality())*loadTime;
	}
	public int getRefillTime()
	{
		return (100.0/getQuality())*refillTime;
	}
	bool isFull()
	{
		return cartridges.Count == capacity;
	}
	bool isEmpty()
	{
		return cartridges.Count == 0;
	}
	void push(Cartridge cartridge)
	{
		cartridges.Push(cartridge);
	}
	Cartridge pop()
	{
		return cartridges.Pop();
	}
}

public class Cartridge : Product
{
	public Bullet bullet;
	public Powder powder;
	public Shell shell;
	public static float HOLLOWPOINT_SPEED_REDUCTION = 0.25://in percent
	public static float HIGHEXPLOSIVE_DAMAGE_FACTOR = 0.75://in percent
	public Cartridge()
	{

	}
	public void assemble(Bullet b, Powder p, Shell s)
	{
		bullet = b;
		powder = p;
		shell = s;
	}
	public float getSpeed()
	{
		float f = powder.getEnergy()/bullet.weight;
		if (bullet.hollowpoint)
		{
			f *= 1.0-HOLLOWPOINT_SPEED_REDUCTION;
		}
		return f;
	}
	public float getAccuracy()
	{

	}
	public void shoot()
	{

	}
}

public Bullet : Product
{
	public float weight;
	public bool armorpiercing;
	public bool fullmetaljacket;
	public bool incendiary;
	public bool highexplosive;
	public bool softpoint;
	public bool hollowpoint;
	public Products material;
	public Bullet()
	{
		weight = 0.0;//weight in grams
		armorpiercing = false;
		fullmetaljacket = false;
		incendiary = false;
		highexplosive = false;
		softpoint = false;
		hollowpoint = false;
	}
}

public Powder : Product
{
	private float energy;
	public Powder()
	{
		energy = 0.0;
	}
	public void setEnergy(float f)
	{
		energy = f;
	}
	public float getEnergy()
	{
		return getQuality()/100*energy;
	}
}

public class Shell : Product
{

}

public class Product : Quality
{
	public int assemblyTime;
	public Product()
	{
		assemblyTime = 0;
	}
}

public class Quality
{
	private float quality;
	private float factor;
	public Quality()
	{
		quality = 0.0;//[0;100)
		factor = 10000;//the bigger the better
	}
	public void adjustFactor(float f)//f>1 means better
	{
		factor *= f;
	}
	public void reduceQuality()
	{
		float missing = 100 - quality;
		missing *= missing;
		missing /= factor;//ql=1->0.98 ql=10->0.81 ql=20->0.64 ql=30->0.49 ql=40->0.36 ql=50->0.25 ql=60->0.16 ql=70->0.09 ql=80->0.04 ql=90->0.01
		setQuality(quality-missing);
	}
	public void increaseQuality()
	{
		float missing = 100 - quality;
		missing *= missing;
		missing /= factor;//ql=1->0.98 ql=10->0.81 ql=20->0.64 ql=30->0.49 ql=40->0.36 ql=50->0.25 ql=60->0.16 ql=70->0.09 ql=80->0.04 ql=90->0.01
		setQuality(quality+missing);
	}
	public bool isDestroyed()
	{
		return quality <= 0;
	}
	public void setQuality(float ql)
	{
		if (ql > 100)
		{
			quality = 100;
		}
		else if (ql < 0)
		{
			quality = 0;
		}
		else
		{
			quality = ql;
		}
	}
	public float getQuality()
	{
		return quality;
	}
}

enum Ingredents
{
	Steel,
	Iron,
	Copper,
	Cellulose,
	Salpeter,
	Nitrocellulose,
	Wood,
	Carbon,
	Sulfur,
	Lead,
	Leadore,
	Copperore,
	Ironore,
	Magnesium
}

enum Products
{
	Steel,
	Iron,
	Copper,
	Cellulose,
	Nitrocellulose,
	Carbon,
	Lead,
	Worker,
}

public class Reciepe
{
	Dictionary ingredents;
	Products product;
	public Reciepe()
	{
		ingredents = new Dictionary<Ingredents, int>();
	}
}

public class Worker
{
	
}

enum NodeType
{
	none,
	block,
	lowerNorth,
	lowerSouth,
	lowerWest,
	lowerEast,
	upperNorth,
	upperSouth,
	upperWest,
	upperEast,
	lowerNorthWest,
	lowerNorthEast,
	lowerSouthWest,
	lowerSouthEast,
	upperNorthWest,
	upperNorthEast,
	upperSouthWest,
	upperSouthEast
}

public class Node
{
	public Vector3 pos;
	public NodeType type;
	public List<Node> neighbours;
	public List<int> neighbourIDs;
	public int id;
	public Node()
	{
		neighbours = new List<Node>();
		neighbourIDs = new List<int>();
		type = NodeType.none;
	}
}

public class Greedy
{
	
}
