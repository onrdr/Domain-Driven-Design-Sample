namespace Domain.Customers;

/*  
    The reason we use a record here is that we want to leverage the benefits of immutability and value-based equality that records provide.
    Also we dont have to implement Equals and GetHashCode methods from Iqeuatable interface ourselves, 
    as records automatically generate these methods based on the properties defined in the record.
*/
public record CustomerId(Guid Value);