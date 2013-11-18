#pragma once

#include <iostream>
#include <math.h>

using namespace std;
template <class T>
class Intervall
{
private:
	T lower;
	T upper;
public:

	Intervall(void)
	{
		lower = 0;
		upper = 0;
	}

	Intervall(T value, double proc)
	{
		lower = value / (1 + (proc / 100));
		upper = value * (1 + (proc / 100));
	}

	~Intervall(void)
	{
	}

	
	T mean()
	{
		return (lower + upper) / 2;
	}

	T absolute_error()
	{
		return abs(lower - upper);
	}

	double relative_error()
	{
		return abs(upper - lower) / mean();
	}

	T getUpper(){return this->upper;}
	void setUpper(T upper){this->upper = upper;}

	T getLower(){return this->lower;}
	void setLower(T lower){this->lower = lower;}

	friend ostream& operator << (ostream &out, Intervall<T> &intervall)
	{
		out<<"["<<intervall.getLower()<<","<<intervall.getUpper()<<"]";
		return out;
	}

	friend Intervall<T> operator + (Intervall<T> &one, Intervall<T> &another)
	{
		Intervall<T> result;
		result.setLower((one.getLower() + another.getLower()));
		result.setUpper((one.getUpper() + another.getUpper()));
		return result;
	}

	friend Intervall<T> operator - (Intervall<T> &one, Intervall<T> &another)
	{
		Intervall<T> result;
		result.setLower((one.getLower() - another.getLower()));
		result.setUpper((one.getUpper() - another.getUpper()));
		return result;
	}

	friend Intervall<T> operator * (Intervall<T> &one, Intervall<T> &another)
	{
		Intervall<T> result;
		T resultValue;

		resultValue = min((one.getLower() * another.getLower()), (one.getLower() * another.getUpper()));
		resultValue = min(resultValue, (one.getUpper() * another.getLower()));
		resultValue = min(resultValue, (one.getUpper() * another.getUpper()));
		result.setLower(resultValue);

		resultValue = max((one.getLower() * another.getLower()), (one.getLower() * another.getUpper()));
		resultValue = max(resultValue, (one.getUpper() * another.getLower()));
		resultValue = max(resultValue, (one.getUpper() * another.getUpper()));
		result.setUpper(resultValue);
		return result;	
	}

	friend Intervall<T> operator / (Intervall<T> &one, Intervall<T> &another)
	{
		Intervall<T> result;
		T resultValue;

		resultValue = min((one.getLower() / another.getLower()), (one.getLower() / another.getUpper()));
		resultValue = min(resultValue, (one.getUpper() / another.getLower()));
		resultValue = min(resultValue, (one.getUpper() / another.getUpper()));
		result.setLower(resultValue);

		resultValue = max((one.getLower() / another.getLower()), (one.getLower() / another.getUpper()));
		resultValue = max(resultValue, (one.getUpper() / another.getLower()));
		resultValue = max(resultValue, (one.getUpper() / another.getUpper()));
		result.setUpper(resultValue);
		return result;
	}
};

