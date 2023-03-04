package graph

import "github.com/Cyberpatinho/Technology/GraphQL/1-Beginning/internal/database"

// This file will not be regenerated automatically.
//
// It serves as dependency injection for your app, add any dependencies you require here.

type Resolver struct {
	MenuDB *database.Menu
}
