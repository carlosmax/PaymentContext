using System;
using System.Collections.Generic;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private List<Subscription> _subscriptions;

        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;

            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions => _subscriptions;

        public void AddSubscription(Subscription subscription)
        {
            bool hasSubscriptionActive = false;

            foreach(var sub in Subscriptions)
            {
                if (sub.Active)
                    hasSubscriptionActive = true;
            }

            AddNotifications(new Contract()                    
                .Requires()
                .IsFalse(hasSubscriptionActive, "Student.Subscription", "Você já tem uma assinatura ativa")
                .AreNotEquals(subscription.Payments.Count, 0, "Student.Subscription.Payments", "Esta assinatura não possui pagamentos")
            );

            _subscriptions.Add(subscription);
        }
    }
}