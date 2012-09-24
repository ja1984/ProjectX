using System.Reflection;
using NHibernate.Mapping.ByCode;

namespace Model.Nhibernate
{
    public class SpotQuizModelInspector : ExplicitlyDeclaredModel
    {
        public override bool IsOneToMany(MemberInfo member)
        {
            return IsBag(member) || base.IsOneToMany(member);
        }

        //public override bool IsOneToOne(MemberInfo member)
        //{
        //    return IsManyToOne(member) || base.IsOneToOne(member);
        //}
    }
}