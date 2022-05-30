Feature: Hello

    Scenario: Hello
        Given that my name is "Orestis"
        When I call Ping
        Then I receive "Hello Orestis"
        
    Scenario: Hello again (This just an example for demonstrating Cucumber)
        Given that my name is "Some random guy"
        When I call Ping
        Then I receive "Hello Some random guy"