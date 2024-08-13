namespace GuitarApp.Models
{
    internal class GuitarSpecs
    {
        public Builder Builder { get; set; }
        public GuitarType GuitarType { get; set; }
        public Wood TopWood { get; set; }
        public Wood BackWood { get; set; }
        //public int StringNumber { get; set; }

        public GuitarSpecs(Builder builder = Builder.Any,
            GuitarType guitarType = GuitarType.Any,
            Wood topWood = Wood.Any,
            Wood backWood = Wood.Any)
        {
            Builder = builder;
            GuitarType = guitarType;
            TopWood = topWood;
            BackWood = backWood;
            //StringNumber = stringNumber;
        }
        public bool Matches(GuitarSpecs otherSpec)
        {
            if (otherSpec.Builder != Builder.Any && Builder != otherSpec.Builder)
                return false;
            if (otherSpec.GuitarType != GuitarType.Any && GuitarType != otherSpec.GuitarType)
                return false;
            if (otherSpec.TopWood != Wood.Any && TopWood != otherSpec.TopWood)
                return false;
            if (otherSpec.BackWood != Wood.Any && BackWood != otherSpec.BackWood)
                return false;

            return true;
        }
    }
}
