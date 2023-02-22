namespace AIE43_TemperatureCalculatorAdvanced
{
    public class Temperature
    {
        public float celcius;
        public float farenheit;

        public Temperature(float _celcius)
        {
            celcius = _celcius;
            ApplyCelciusToFarenheit();
        }

        private void ApplyCelciusToFarenheit()
        {
            farenheit = (celcius * 9 / 5) + 32;
        }

        public static bool operator == (Temperature _lhs, Temperature _rhs)
        {
            //return _lhs.celcius.Equals(_rhs.celcius);
            return _lhs.celcius - _rhs.celcius < float.Epsilon && _lhs.celcius - _rhs.celcius > -float.Epsilon;
        }

        public static bool operator != (Temperature _lhs, Temperature _rhs)
        {
            return !(_lhs == _rhs);
        }

        public static Temperature operator +(Temperature _lhs, Temperature _rhs)
        {
            Temperature t = new Temperature(0f);
            t.celcius = _lhs.celcius + _rhs.celcius;
            t.ApplyCelciusToFarenheit();
            return t;
        }

        public static implicit operator float(Temperature _temperature)
        {
            return _temperature.celcius;
        }
    }
}
