namespace BoraRachar.Infra.Data.Repository.Orm.Filter;

public enum WhereOperator
{
    Equals,
    NotEquals,
    GreaterThan,
    LessThan,
    GreaterThanOrEqualTo,
    LessThanOrEqualTo,
    Contains,
    StartsWith,
    LessThanOrEqualWhenNullable,
    GreaterThanOrEqualWhenNullable
}
