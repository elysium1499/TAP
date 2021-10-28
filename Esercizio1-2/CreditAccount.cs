using System;

namespace Esercizio1_2
{
    public class CreditAccount				//se non definisco public come tipo di classe viene preso il tipo  di default internal
    {
		private static long nextId;
		public static readonly int default_limit = 0; // in cents

		private int limit; // in cents
		private int balance; // in cents
		public readonly Person owner;
		public readonly long id;

		// private auxiliary static methods for validation and identifier generation

		private static Person requireNonNull(Person p)
		{
			if (p == null)
				throw new ArgumentNullException();
			return p;
		}

		private static int requirePositive(int amount)
		{
			if (amount <= 0)
				throw new ArgumentNullException();
			return amount;
		}

		private static int requireLimitBelowBalance(int limit, int balance)
		{
			if (limit > balance)
				throw new ArgumentNullException();
			return limit;
		}

		private static long NextId()
		{
			if (CreditAccount.nextId < 0)
				throw new Exception("No more available ids");
			return CreditAccount.nextId++;
		}

		// constructors

		public CreditAccount(int limit, int balance, Person owner)
		{
			this.balance = CreditAccount.requirePositive(balance);
			this.limit = CreditAccount.requireLimitBelowBalance(limit, balance);
			this.owner = CreditAccount.requireNonNull(owner);
			this.id = CreditAccount.NextId();
		}

		public CreditAccount(int balance, Person owner) : this (CreditAccount.default_limit, balance, owner) { }		//richiamare un costrutto- non usiamo il this()
	
		// static factory methods

		public static CreditAccount newOfLimitBalanceOwner(int limit, int balance, Person owner)
		{
			return new CreditAccount(limit, balance, owner);
		}

		public static CreditAccount newOfBalanceOwner(int balance, Person owner)
		{
			return new CreditAccount(balance, owner);
		}

		// instance methods

		public int deposit(int amount)
		{ // amount in cents
			return this.balance += CreditAccount.requirePositive(amount);
		}

		public int withdraw(int amount)
		{ // amount in cents
			int newBalance = Math.Abs(this.balance - CreditAccount.requirePositive(amount)); // balance can be negative, overflow is possible!
			CreditAccount.requireLimitBelowBalance(this.limit, newBalance);
			return this.balance = newBalance;
		}

		public int getBalance()
		{
			return this.balance;
		}

		public int getLimit()
		{
			return this.limit;
		}

		public void setLimit(int limit)
		{ // setter method
			this.limit = CreditAccount.requireLimitBelowBalance(limit, this.balance);
		}


	}
}
