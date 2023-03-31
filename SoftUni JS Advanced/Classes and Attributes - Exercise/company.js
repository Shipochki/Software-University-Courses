class Company {
    constructor() {
        this.departments = {}
    }

    addEmployee(first, second, third, forth) {
        let name = first;
        if (typeof name !== 'string'
            || name === null || name === undefined
            || name === '') {
            throw Error('Invalid input!');
        }

        let salary = second;
        if (typeof salary !== 'number' || salary < 0) {
            throw Error('Invalid input!');
        }

        let postion = third;
        if (typeof postion !== 'string') {
            throw Error('Invalid input!');
        }

        let department = forth;
        if (typeof department !== 'string') {
            throw Error('Invalid input!');
        }

        if (!(department in this.departments)) {
            this.departments[department] = {
                employes: [],
                avgSalary() {
                    return this.employes.reduce((p, c) => p + c.salary, 0) / this.employes.length
                }
            }
        }
        
        this.departments[department].employes.sort((a, b) => a.salary - b.salary).push({
            name: name,
            salary: salary,
            postion: postion
        });

        this.departments[department].employes.reverse()
    }

    bestDepartment() {
        let highestKey = Object.keys(this.departments).sort((a = this.avgSalary(), b = this.avgSalary()) => b - a)[0];
        let department = this.departments[highestKey];
        let result = `Best Department is: ${highestKey} \n`;
        result += `Average salary: ${(department.avgSalary().toFixed(0))} \n`;
        for (let i = 0; i < department.employes.length; i++) {
            const employee = department.employes[i];
            result += `${employee.name} ${employee.salary} ${employee.postion} \n`;
        }

        return result;
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());

let c2 = new Company();

c2.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c2.addEmployee("Slavi", 500, "dyer", "Construction");
c2.addEmployee("Stan", 2000, "architect", "Construction");
c2.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c2.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c2.addEmployee("Gosho", 1350, "HR", "Human resources");

console.log(c2.bestDepartment());