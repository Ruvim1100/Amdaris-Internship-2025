#What code smells did you see?
Long Method: Original Register method was large and tried to do too many things.
Commented Out Code: There were comments used instead of clean readable code.
Magic Strings: Hardcoded domains and validation logic were mixed together.
Lack of SRP: The Speaker class handled validation, business logic, and data storage.
Poor Naming: Variable and method names didn’t clearly express their purpose.

#What problems do you think the original Speaker class had?
Mixed concerns: validation, eligibility, and persistence logic were all within a single class.
Hard to test and extend.
Difficult to reuse parts independently (e.g., validation logic).
Not maintainable in the long term, especially when business logic evolves.

#Which clean code / SOLID principles were violated?
Principle	Violation
SRP (Single Responsibility)	Speaker was doing everything: validation, formatting, and data handling
OCP (Open/Closed)	Hardcoded business rules made the class hard to extend without modifying
LSP (Liskov Substitution)	Would break if used in other contexts due to tight validation logic
ISP (Interface Segregation)	N/A (but could apply with abstraction over email validation or repository)
DIP (Dependency Inversion)	No abstractions; tightly bound logic

#What refactoring techniques did you use?
Extract Method: Moved validation logic into SpeakerValidator class.
Encapsulation: Created clean constructors and RegistrationResult for clarity.
Separation of Concerns: Split domain model (Speaker, Session) from logic (SpeakerValidator).
SRP enforcement: Each class now has one responsibility.
Created helper methods: For readability and testability.