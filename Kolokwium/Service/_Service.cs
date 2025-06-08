using Kolokwium.Data;
using Kolokwium.DTOs;
using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Service;

public class _Service
{
    public _DbContext _context;

    public _Service(_DbContext context)
    {
        _context = context;
    }


    public async Task<CustomerPurchasesDto> getCustomerPurchases(int id)
    {
        var customerPurchases = await _context.Customers.Where(p => p.CustomerId == id).Select(c => new CustomerPurchasesDto
        {
            firstName = c.FirstName,
            lastName = c.LastName,
            phoneNumber = c.PhoneNumber,
            Purchases = _context.PurchaseHistories.Where(p => p.CustomerId == id).Select(p => new PurchasesDto
            {
                date = p.PurchaseDate,
                rating = p.Rating,
                price = p.AvailableProgram.Price,
                washingMachine = new WashingMachineDto
                {
                    serial = p.AvailableProgram.WashingMachine.SerialNumber,
                    maxWeight = p.AvailableProgram.WashingMachine.MaxWeight,
                },
                program = new ProgramDto()
                {
                    name = p.AvailableProgram.Program.Name,
                    duration = p.AvailableProgram.Program.DurationMinutes
                }
            }).ToList()
        }).FirstOrDefaultAsync();
        if (customerPurchases == null)
            throw new NullReferenceException();
        
        return customerPurchases;
    }

    public async Task addWashingMachine(AddWashingMashineDto dto)
    {
            var avaliablePrograms = new List<AvailableProgram>();
            foreach (var program in dto.avaliablePrograms)
            {
                var newProgram = await _context.AvailablePrograms
                    .Where(a => a.WashingMachine.SerialNumber == dto.washingMashine.serialNumber)
                    .FirstOrDefaultAsync(a => a.Program.Name == program.programName);
                if (newProgram == null)
                    throw new NullReferenceException();
                avaliablePrograms.Add(newProgram);
            }

            var oldWashingMashine = await _context.WashingMachines
                .Where(w => w.SerialNumber == dto.washingMashine.serialNumber).FirstOrDefaultAsync();
            if (oldWashingMashine != null)
            {
                throw new AlreadyExists();
            }

            var washingMashine = new WashingMachine()
            {
                MaxWeight = dto.washingMashine.maxWeight,
                SerialNumber = dto.washingMashine.serialNumber,
                AvailablePrograms = avaliablePrograms
            };
            
            await _context.AddAsync(washingMashine);
            await _context.SaveChangesAsync();
      
    }
}