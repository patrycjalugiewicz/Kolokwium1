﻿using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Models;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    [MaxLength(100)]
    public string? PhoneNumber { get; set; }
    public ICollection<PurchaseHistory> PurchaseHistory { get; set; }
}