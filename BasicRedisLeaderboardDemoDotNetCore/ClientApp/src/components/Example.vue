<template>
  <v-container class="example">
    <v-row class="mb-5">
      <v-col cols="12">
        <v-expansion-panels
          v-model="panel"
          multiple
        >
          <v-expansion-panel>
            <v-expansion-panel-header>How it works?</v-expansion-panel-header>
            <v-expansion-panel-content> 
              <b>1. How the data is stored:</b>
              <ol>
                <li>The company data is stored in a hash like below:
                  <pre>HSET "company:AAPL" symbol "AAPL" market_cap "2600000000000" country USA</pre>
                 </li>
                <li>The Ranks are stored in a ZSET. 
                  <pre>ZADD companyLeaderboard 2600000000000 company:AAPL</pre>
                </li>
              </ol>

              <br/>
              <b>2. How the data is accessed:</b>
              <ol>
                <li>Top 10 companies: <pre>ZREVRANGE companyLeaderboard 0 9 WITHSCORES</pre> </li>
                <li>All companies: <pre>ZREVRANGE companyLeaderboard 0 -1 WITHSCORES</pre> </li>
                <li>Bottom 10 companies: <pre>ZRANGE companyLeaderboard 0 9 WITHSCORES</pre></li>
                <li>Between rank 10 and 15: <pre>ZREVRANGE companyLeaderboard 9 14 WITHSCORES</pre></li>
                <li>Show ranks of AAPL, FB and TSLA: <pre>ZSCORE companyLeaderBoard company:AAPL company:FB company:TSLA</pre> </li>
                <!-- <li>Pagination: Show 1st 10 companies: <pre>ZSCAN 0 companyLeaderBoard COUNT 10 7.Pagination: Show next 10 companies: ZSCAN &lt;return value from the 1st 10 companies&gt; companyLeaderBoard COUNT 10 </li> -->
                <li>Adding market cap to companies: <pre>ZINCRBY companyLeaderBoard 1000000000 "company:FB"</pre></li>
                <li>Reducing market cap to companies: <pre>ZINCRBY companyLeaderBoard -1000000000 "company:FB"</pre></li>
                <li>Companies over a Trillion: <pre>ZCOUNT companyLeaderBoard 1000000000000 +inf</pre> </li>
                <li>Companies between 500 billion and 1 trillion: <pre>ZCOUNT companyLeaderBoard 500000000000 1000000000000</pre></li>
              </ol>
            </v-expansion-panel-content>
          </v-expansion-panel>
        </v-expansion-panels>
      </v-col>
    </v-row>

    <v-row>
      <v-col cols="4">
        <v-select
          :items="ACTION_LIST"
          v-model="method"
          dense
          outlined
          hide-details
          style="background: #FFF"
        />
      </v-col>
      <v-col cols="8" class="text-right">
        <rank-selection-modal
          v-model="rankForm"
          :companies="companies"
          @onUpdateRank="onUpdateRank"
        >
          <template v-slot:activator="{ on }">
            <v-btn
              color="grey"
              v-on="on"
              outlined
            >
              <v-icon class="mr-2">mdi-cog-outline</v-icon>
              <span style="color: #111; text-transform: initial;">Update Rank</span>
            </v-btn>
          </template>
        </rank-selection-modal>
      </v-col>
    </v-row>

    <v-row>
      <v-col cols="12">
        <v-card style="border-right: 10px" class="px-2">
          <v-data-table
            :headers="headers"
            :items="companies"
            :loading="loading"
            :disable-pagination="true"
            :hide-default-footer="true"
          >
            <template v-slot:item.rank="{ item }">
              {{ item.rank }}
            </template>
            <template v-slot:item.company="{ item }">
              <div class="d-flex align-center py-2">
                <div>
                  <img
                    :src="`https://companiesmarketcap.com//img/company-logos/80/${item.symbol.toUpperCase()}.png`"
                    width="40"
                    height="40"
                    class="mr-3 my-2"
                  />
                </div>
                <div>
                  <div class="" style="font-size: 1.1rem">{{ item.company }}</div>
                  <div class="grey--text" style="font-size: 0.7rem">{{ item.symbol.toUpperCase() }}</div>
                </div>
              </div>
            </template>
            <template v-slot:item.marketCap="{ item }">
              <div class="">{{ formatUSD(item.marketCap) }}</div>
            </template>
            <template v-slot:item.country="{ item }">
              <div class="d-flex align-center">
                <div>
                  <img
                    :src="getCountryFlag(item.country)"
                    width="20"
                    class="mr-1"
                  />
                </div>
                <div class="">{{ item.country }}</div>
              </div>
            </template>


            <template v-slot:no-data>
              <span> No Results Found. </span>
            </template>
          </v-data-table>
          <v-btn
            v-if="method === 'paginate'"
            color="primary"
            block
            @click="loadData"
          >
            Load next 10
          </v-btn>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import axios from 'axios'
import { findFlagUrlByCountryName } from "country-flags-svg";

const TRILLION = 1000 * 1000 * 1000 * 1000;
const BILLION = 1000 * 1000 * 1000;
const MILLION = 1000 * 1000;

const API_BASE = location.hostname === 'localhost'
  ? 'http://localhost:5000/api'
  : location.origin + '/api'

import RankSelectionModal from './RankSelectionModal'
export default {
  name: 'Example',

  components: {
    RankSelectionModal,
  },

  props: {
  },

  data: () => ({
    loading: false,
    companies: [],
    headers: [
      { text: 'Rank', value: 'rank', sortable: false },
      { text: 'Name', value: 'company', sortable: false },
      { text: 'Market Cap', value: 'marketCap', sortable: false },
      { text: 'Country', value: 'country', sortable: false },
    ],
    method: 'top10',
    rankForm: {
      symbol: '',
      op: '',
      amount: '',
    },
    startPaginate: 0,
    ACTION_LIST: [
      { text: 'Top 10 companies', value: 'top10' },
      { text: 'All companies', value: 'all' },
      { text: 'Bottom 10 companies', value: 'bottom10' },
      { text: 'Between Rank 10 & 15', value: 'inRank?start=9&end=14' },
      { text: 'Show Ranks of AAPL, FB and TSLA', value: 'getBySymbol?symbols[]=aapl&symbols[]=fb&symbols[]=tsla' },
      { text: 'Pagination: Show 1st 10', value: 'paginate' },
      // { text: 'Pagination: Show Next 10', value: 'paginate' },
    ],
    panel: null,
  }),

  computed: {
  },

  watch: {
    method: {
      handler () {
        this.loadData()
      },
      immediate:true,
    },
  },

  created () {
  },

  methods: {
    async onUpdateRank () {
      this.loading = true
      try {
        const form = {
          symbol: this.rankForm.symbol,
          amount: this.rankForm.op === 'add' ? this.rankForm.amount : -1 * this.rankForm.amount,
        }

        await axios.get(`${API_BASE}/rank/update`, { params: form })

        this.rankForm = {
          symbol: '',
          op: '',
          amount: '',
        }
        this.loadData()
      } catch (err) {
        console.log(err)
        // catch err
      }
      this.loading = false
    },
    async loadData () {      
      this.loading = true
      try {
        let method = this.method
        if (this.method === 'paginate') {
          method = `inRank?start=${this.startPaginate}&end=${this.startPaginate+10}`
          this.startPaginate += 10
        }

        const apiResp = await axios.get(`${API_BASE}/list/${method}`)
        this.companies = apiResp.data
      } catch (err) {
        console.log(err)
        // catch err
      }
      this.loading = false
    },
    formatUSD (usd) {
      if (usd > TRILLION) {
        return `$${(usd / TRILLION).toFixed(3)} T`
      }
      if (usd > BILLION) {
        return `$${(usd / BILLION).toFixed(2)} B`
      }
      if (usd > MILLION) {
        return `$${(usd / MILLION).toFixed(1)} M`
      }
      return `$ ${usd}`
    },
    getCountryFlag (cName) {
      const matchUp = {
        'S. Arabia': 'Saudi Arabia',
        'S. Korea': 'South Korea',
      }
      const country = findFlagUrlByCountryName(matchUp[cName] || cName)
      return country
    },
  },
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
::v-deep .v-data-table > .v-data-table__wrapper > table > thead > tr > th {
  color: #444;
}
::v-deep .v-data-table {
  color: #212529;
  font-weight: 500;
}
</style>
