using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Model.Nhibernate
{
    public class MyIdConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.GeneratedBy.HiLo("100");
            instance.Column(instance.EntityType.Name + "Id");
        }
    }
}